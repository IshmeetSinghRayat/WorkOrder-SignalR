using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Model;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    [Authorize]
    public class RiderController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ILookupService _lookupService;
        private readonly IHubContext<SignalServer> _hubContext;
        private readonly IAttachmentsService _attachmentsService;

        public RiderController(ITransactionService transactionService,
            ILookupService lookupService,
            IHubContext<SignalServer> hubContext,
            IAttachmentsService attachmentsService)
        {
            _transactionService = transactionService;
            _lookupService = lookupService;
            _hubContext = hubContext;
            _attachmentsService = attachmentsService;
        }
        // GET: RiderController
        public async Task<ActionResult> Index()
        {
            var ss = User.Claims;
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
            ViewBag.currentStatus = transactionDetails.JobCardsTransactionsStatus;
            ViewBag.TransactionId = Id;
            var Data = await _lookupService.GetLookups("TransactionStatus");
            return View(Data.Where(c=>c.Alias != "Cancel").ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ChangeTransactionStatus(short id, string status)
        {
            if (id == 0)
            {
                return View();
            }
            RiderChangeStatusViewModel model = new RiderChangeStatusViewModel
            {
                Id = id,
                JobCardsTransactionsStatus = status
            };
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

        public ActionResult AddAttachment(short transactionId)
        {
            ViewBag.TransactionId = transactionId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAttachment(List<IFormFile> files, short transactionId, string description)
        {
            List<JobCardsTransactionsLobs> model = new List<JobCardsTransactionsLobs>();
            foreach (var file in files)
            {
                JobCardsTransactionsLobs obj = new JobCardsTransactionsLobs();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    obj.Lobdata = stream.ToArray();
                    obj.JobCardsTransactionsId = transactionId;
                    obj.DocumentDescription = description;
                    obj.CreatedDate = DateTime.Now;
                    obj.FileType = file.ContentType;
                }
                model.Add(obj);
            }
            if (model != null)
            {
                if (await _attachmentsService.PostAttachments(model))
                {
                    return RedirectToAction("Index");

                }
            }
            return View();
        }

        public async Task<ActionResult> ShowAttachment(short transactionId)
        {
            return View(await _attachmentsService.GetAttachmentsByTransactionId(transactionId));
        }

        [HttpPost]
        public async Task<ActionResult> ShowAttachment(List<IFormFile> files, short transactionId, string description)
        {
            List<JobCardsTransactionsLobs> model = new List<JobCardsTransactionsLobs>();
            foreach (var file in files)
            {
                JobCardsTransactionsLobs obj = new JobCardsTransactionsLobs();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    obj.Lobdata = stream.ToArray();
                    obj.JobCardsTransactionsId = transactionId;
                    obj.DocumentDescription = description;
                    obj.CreatedDate = DateTime.Now;
                }
                model.Add(obj);
            }
            if (model != null)
            {
                if (await _attachmentsService.PostAttachments(model))
                {
                    return RedirectToAction("Index");

                }
            }
            return View();
        }

        public async Task<IActionResult> ViewDocument(short id) {
            if (id != 0)
            {
                JobCardsTransactionsLobs obj = await _attachmentsService.GetAttachmentById(id);
                return File(obj.Lobdata, obj.FileType);
            }
            return View();
        }
    }
}
