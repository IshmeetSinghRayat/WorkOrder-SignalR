using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WorkOrderApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WorkOrderCore.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WorkOrderApplication.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityLoginProjectUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<IdentityLoginProjectUser> _userManager;

        public LoginModel(SignInManager<IdentityLoginProjectUser> signInManager,
            ILogger<LoginModel> logger,
            IEmployeeService employeeService,
            UserManager<IdentityLoginProjectUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _employeeService = employeeService;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var employeeDetails = await _employeeService.GetEmployeeDetails(Input.Email);
                    if (employeeDetails == null)
                    {
                        return Page();
                    }
                    _logger.LogInformation("User logged in.");
                    HttpContext.Session.SetString("LoginUserid", employeeDetails.UserId);
                    HttpContext.Session.SetString("EmployeeId", employeeDetails.EmployeeId.ToString());
                    HttpContext.Session.SetString("EmailId", Input.Email.ToString());

                    var user = await _userManager.FindByEmailAsync(Input.Email);

                    var roles = await _userManager.GetRolesAsync(user);
                    if (user != null)
                    {
                        var userClaims = new List<Claim>()
                    {
                        new Claim("UserName", user.UserName),
                        new Claim(ClaimTypes.Name, user.Firstname),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                    };

                        var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                        var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                        //HttpContext.User = userPrincipal;
                        await HttpContext.SignInAsync(userPrincipal);
                    }

                    if (roles.Where(c => roles.Contains("Employee")).Any())
                    {
                        return RedirectToAction("index", "Rider");
                    }
                    else
                    {
                        return RedirectToAction("index", "JobCards");
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
