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
        private readonly ITransactionService _assignActivityService;
        private readonly IEmployeeService _employeeService;
        private readonly IActivityService _activityService;
        private readonly IJobCardService _jobCardService;

        public TransactionController(
            ITransactionService assignActivityService, 
            IEmployeeService employeeService,
            IActivityService activityService,
            IJobCardService jobCardService)
        {
            _assignActivityService = assignActivityService;
            _employeeService = employeeService;
            _activityService = activityService;
            _jobCardService = jobCardService;
        }
        // GET: AssignActivityController
        public async Task<ActionResult> Index()
        {
            return View(await _assignActivityService.GetAllAssignedActivities());
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
                TransactionDetails = new WorkOrderCore.Infrastructure.Persistence.DataContext.JobCardsTranasctions(),
                EmployeesDD = ridersList.Select(c => new SelectListItem { Text = c.Id.ToString(), Value = c.Id.ToString() }).ToList(),
                JobcardDD = jobCardList.Select(c => new SelectListItem { Text = c.Id.ToString(), Value = c.Id.ToString() }).ToList(),
                JobActivityDD = activityList.Select(c => new SelectListItem { Text = c.Id.ToString(), Value = c.Id.ToString() }).ToList()
            };
            return View();
        }

        // POST: AssignActivityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel model)
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
