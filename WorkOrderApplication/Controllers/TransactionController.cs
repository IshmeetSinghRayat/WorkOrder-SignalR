using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderApplication.Models;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IEmployeeService _employeeService;
        private readonly IActivityService _activityService;
        private readonly IJobCardService _jobCardService;

        public TransactionController(
            ITransactionService transactionService, 
            IEmployeeService employeeService,
            IActivityService activityService,
            IJobCardService jobCardService)
        {
            _transactionService = transactionService;
            _employeeService = employeeService;
            _activityService = activityService;
            _jobCardService = jobCardService;
        }
        // GET: AssignActivityController
        public async Task<ActionResult> Index()
        {
            return View(await _transactionService.GetAllTransactions());
        }

        // GET: AssignActivityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssignActivityController/Create
        public async Task<ActionResult> Create()
        {
            var ridersList = await _employeeService.GetAllRiders(1);
            var jobCardList = await _jobCardService.GetAllJobCards();
            var activityList = await _activityService.GetAllActivities();
            TransactionViewModel model = new TransactionViewModel
            {
                EmployeesDD = ridersList.Select(c => new SelectListItem { Text = c.FullName.ToString(), Value = c.EmployeeId.ToString() }).ToList(),
                JobcardDD = jobCardList.Select(c => new SelectListItem { Text = c.JobDescription.ToString(), Value = c.Id.ToString() }).ToList(),
                JobActivityDD = activityList.Select(c => new SelectListItem { Text = c.JobActivityDescriptioin.ToString(), Value = c.Id.ToString() }).ToList(),
                TransactionDetails = new WorkOrderCore.Infrastructure.Persistence.DataContext.JobCardsTranasctions 
                { 
                    JobCardsTranasctionsEndDate = DateTime.Now,
                    JobCardsTranasctionsStartDate = DateTime.Now,
                    JobCardsTranasctionsClosedAt = DateTime.Now,
                    JobCardsTranasctionsStatus = "Open"
                }
            };
            return View(model);
        }

        // POST: AssignActivityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel model)
        {
            try
            {
                var result = _transactionService.AddTransaction(model.TransactionDetails);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignActivityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
