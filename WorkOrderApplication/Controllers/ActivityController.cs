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
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly ILookupService _lookupService;
        private readonly IHubContext<SignalServer> _hubContext;

        public ActivityController(IActivityService activityService, 
            ILookupService lookupService,
            IHubContext<SignalServer> hubContext)
        {
            _activityService = activityService;
            _lookupService = lookupService;
            _hubContext = hubContext;
        }
        // GET: ActivityController
        public async Task<ActionResult> Index()
        {
            var cc = HttpContext.Session.GetString("UserId");
            var ccdds = HttpContext.Session.GetString("EmployeeId");
            ViewBag.businessUnitsList = await _lookupService.GetBusinessUnits();
            var ActivityList = await _activityService.GetAllActivities();
            return View(ActivityList);
        }

        // GET: ActivityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActivityController/Create
        public async Task<ActionResult> Create()
        {
            var businessUnitsList = await _lookupService.GetBusinessUnits();
            var StatusList = await _lookupService.GetLookups(DataEnums.MasterLookupAlias.ActivityStatus.ToString());
            var DurationList = await _lookupService.GetLookups(DataEnums.MasterLookupAlias.Duration.ToString());
            CreateActivityViewModel model = new CreateActivityViewModel
            {
                BusinessUnitsDD = businessUnitsList.Select(v => new SelectListItem { Text = v.Description, Value = v.Id.ToString() }).ToList(),
                StatusDD = StatusList.Select(v => new SelectListItem { Text = v.Name, Value = v.Alias.ToString() }).ToList(),
                DurationDD = DurationList.Select(v => new SelectListItem { Text = v.Name, Value = v.Alias }).ToList(),
                JobActivitiesDetails = new JobActivities
                {
                    JobActivitiesStatus = "Open"
                }
            };
            return View(model);
        }

        // POST: ActivityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateActivityViewModel model)
        {
            try
            {
                var activityDetails = await _activityService.AddActivity(model.JobActivitiesDetails);
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "", "");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ActivityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActivityController/Edit/5
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

        // GET: ActivityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActivityController/Delete/5
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
