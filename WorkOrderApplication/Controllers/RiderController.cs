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
        private readonly ITransactionService _transactionService;
        private readonly ILookupService _lookupService;

        public RiderController(ITransactionService transactionService, ILookupService lookupService)
        {
            _transactionService = transactionService;
            _lookupService = lookupService;
        }
        // GET: RiderController
        public async Task<ActionResult> Index()
        {
            return View(await _transactionService.GetEmployeeTransactions());
        }

        // GET: RiderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RiderController/Create
        public async Task<ActionResult> ChangeStatus()
        {
            return View(await _lookupService.GetLookups("TransactionStatus"));
        }

        // POST: RiderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(IFormCollection collection)
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
