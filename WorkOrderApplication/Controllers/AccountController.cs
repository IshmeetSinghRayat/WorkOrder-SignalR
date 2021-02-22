using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrderApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return LocalRedirect("/identity/account/Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginUserid");
            HttpContext.Session.Remove("EmployeeId");
            return RedirectToAction("/identity/account/Login");
        }

    }
}
