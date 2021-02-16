using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    public class RiderController : Controller
    {
        private readonly IActivityService _activityService;

        public RiderController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        // GET: RiderController
        public async Task<ActionResult> Index()
        {
            return View(await _activityService.GetAllActivities());
        }

        // GET: RiderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RiderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RiderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RiderController/Edit/5
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

        // GET: RiderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RiderController/Delete/5
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
