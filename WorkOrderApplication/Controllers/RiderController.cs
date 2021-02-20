using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Model;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    public class RiderController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ILookupService _lookupService;
        private readonly IHubContext<SignalServer> _hubContext;

        public RiderController(ITransactionService transactionService, ILookupService lookupService, IHubContext<SignalServer> hubContext)
        {
            _transactionService = transactionService;
            _lookupService = lookupService;
            _hubContext = hubContext;
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
        public async Task<ActionResult> ChangeStatus(short Id)
        {
            var transactionDetails = await _transactionService.GetTransactionByTransactionId(Id);
            ViewBag.currentStatus = transactionDetails.JobCardsTranasctionsStatus;
            ViewBag.TransactionId = Id;
            return View(await _lookupService.GetLookups("TransactionStatus"));
        }

        // POST: RiderController/Create
        [HttpPost]
        public async Task<ActionResult> ChangeTransactionStatus([FromBody] RiderChangeStatusViewModel model)
        {
            bool success = false;
            string message = "";
            try
            {
                success = await _transactionService.UpdateTransaction(model);
                if (success)
                {
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", "", "");
                }
                return Json(new { success, message });
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
