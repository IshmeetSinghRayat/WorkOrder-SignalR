using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class JobCardsController : Controller
    {
        private readonly IJobCardService _jobCardService;
        private readonly ILookupService _lookupService;

        public JobCardsController(IJobCardService jobCardService, ILookupService lookupService)
        {
            _jobCardService = jobCardService;
            _lookupService = lookupService;
        }
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("UnAuthorized", "Account");
            }
            ViewBag.businessUnitsList = await _lookupService.GetBusinessUnits();
            return View(await _jobCardService.GetAllJobCards());
        }

        public async Task<ActionResult> CheckDuplicateJobNumber(string number)
        {
            bool success = await _jobCardService.CheckDuplicateJobNumber(number);
            return Json(new { success });
        }

        public async Task<ActionResult> Create(int id = 0, string viewType = "create")
        {
            var businessUnitsList = await _lookupService.GetBusinessUnits();
            var StatusList = await _lookupService.GetLookups(DataEnums.MasterLookupAlias.JobStatus.ToString());
            var DurationList = await _lookupService.GetLookups(DataEnums.MasterLookupAlias.Duration.ToString());
            CreateJobCardViewModel model = new CreateJobCardViewModel
            {
                BusinessUnitsDD = businessUnitsList.Select(v => new SelectListItem { Text = v.Description, Value = v.Id.ToString() }).ToList(),
                StatusDD = StatusList.Select(v => new SelectListItem { Text = v.Name, Value = v.Alias.ToString() }).ToList(),
                DurationDD = DurationList.Select(v => new SelectListItem { Text = v.Name, Value = v.Alias }).ToList(),
                JobCardDetails = new JobCards
                {
                    JobStatus = "Open"
                }
            };
            if (viewType == "edit")
            {
                model.JobCardDetails = await _jobCardService.GetJobCardsById(id);
            }
            ViewBag.CurrentYear = DateTime.Now.Year;
            ViewBag.viewType = viewType;
            return View(model);
        }

        [HttpPost]
   
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateJobCardViewModel details)
        {
            bool result = false;
            try
            {
                if (details.JobCardDetails.Id == 0)
                {
                    result = await _jobCardService.AddJobCard(details.JobCardDetails);
                }
                else
                {
                    result = await _jobCardService.UpdateJobCard(details.JobCardDetails);

                }
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobCardsController/Delete/5
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
