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
        // GET: JobCardsController
        public async Task<ActionResult> Index()
        {
            ViewBag.businessUnitsList = await _lookupService.GetBusinessUnits();
            return View(await _jobCardService.GetAllJobCards());
        }

        // GET: JobCardsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobCardsController/Create
        public async Task<ActionResult> Create()
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
            return View(model);
        }

        // POST: JobCardsController/Create
        [HttpPost]
   
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateJobCardViewModel details)
        {
            try
            {
                var dd = await _jobCardService.AddJobCard(details.JobCardDetails);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobCardsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobCardsController/Edit/5
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

        // GET: JobCardsController/Delete/5
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
