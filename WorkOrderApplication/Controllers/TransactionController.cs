using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderApplication.Models;
using WorkOrderCore.Infrastructure.Helpers;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IEmployeeService _employeeService;
        private readonly IActivityService _activityService;
        private readonly IJobCardService _jobCardService;
        private readonly IHubContext<SignalServer> _hubContext;
        private readonly ILookupService _lookupServcie;

        public TransactionController(
            ITransactionService transactionService, 
            IEmployeeService employeeService,
            IActivityService activityService,
            IJobCardService jobCardService,
            IHubContext<SignalServer> hubContext,
            ILookupService lookupServcie)
        {
            _transactionService = transactionService;
            _employeeService = employeeService;
            _activityService = activityService;
            _jobCardService = jobCardService;
            _hubContext = hubContext;
            _lookupServcie = lookupServcie;
        }
        // GET: AssignActivityController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("UnAuthorized", "Account");
            }
            return View(await _transactionService.GetAllTransactions());
        }

        // GET: AssignActivityController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("UnAuthorized", "Account");
            }
            return View();
        }

        // GET: AssignActivityController/Create
        public async Task<ActionResult> Create()
        {
            var ridersList = await _employeeService.GetAllRiders(1);
            var jobCardList = await _jobCardService.GetAllJobCards();
            var activityList = await _activityService.GetAllActivities();
            var StatusList = await _lookupServcie.GetLookups(DataEnums.MasterLookupAlias.JobStatus.ToString());
            TransactionViewModel model = new TransactionViewModel
            {
                EmployeesDD = ridersList.Select(c => new SelectListItem { Text = c.FullName.ToString(), Value = c.EmployeeId.ToString() }).ToList(),
                JobcardDD = jobCardList.Select(c => new SelectListItem { Text = c.JobDescription.ToString(), Value = c.Id.ToString() }).ToList(),
                JobActivityDD = activityList.Select(c => new SelectListItem { Text = c.JobActivityDescriptioin.ToString(), Value = c.Id.ToString() }).ToList(),
                StatusDD = StatusList.Select(v => new SelectListItem { Text = v.Name, Value = v.Alias.ToString() }).ToList(),
                TransactionDetails = new WorkOrderCore.Infrastructure.Persistence.DataContext.JobCardsTransactions 
                { 
                    JobCardsTransactionsEndDate = DateTime.Now,
                    JobCardsTransactionsStartDate = DateTime.Now,
                    JobCardsTransactionsClosedAt = DateTime.Now,
                    JobCardsTransactionsStatus = "Open"
                }
            };
            return View(model);
        }
        public async Task<IActionResult> GetActivitiesByJobCardId(short jobCardId) {
            var activityList = await _activityService.GetActivitiesByJobCardId(jobCardId);
            var JobActivityDD = activityList
                                    .Select(c => new SelectListItem { Text = c.JobActivityDescriptioin.ToString(), Value = c.Id.ToString() }).ToList();
            return Json(JobActivityDD);
        }

        // POST: AssignActivityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransactionViewModel model)
        {
            try
            {
                var result = await _transactionService.AddTransaction(model.TransactionDetails);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignActivityController/Edit/5
        public async Task<ActionResult> Edit(TransactionViewModel model)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("UnAuthorized", "Account");
            }
            try
            {
                if (await _transactionService.CheckDuplicatePrioritySequence(model.TransactionDetails.JobCardId, model.TransactionDetails.PrioritySequence.Value))
                {
                    return View();
                }
                var result = _transactionService.AddTransaction(model.TransactionDetails);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AssignActivityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignActivityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssignActivityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
