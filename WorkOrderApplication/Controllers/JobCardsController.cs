using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderApplication.Models;
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
            return View(await _jobCardService.GetAllJobCards());
        }

        // GET: JobCardsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobCardsController/Create
        public async Task<ActionResult> Create(CreateJobCardViewModel model)
        {
            var businessUnitsData = await _lookupService.GetBusinessUnits();
            model.JobCardDetails = new JobCards();
            model.BusinessUnitsList = businessUnitsData.Select(v => new SelectListItem { Text = v.BusinessUniteDesc, Value = v.BusinessUnitId.ToString() }).ToList();
            return View(model);
        }

        // POST: JobCardsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCards JobCardDetails)
        {
            try
            {
                var dd = _jobCardService.AddJobCard(JobCardDetails);
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
