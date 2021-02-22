using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Services;

namespace WorkOrderApplication.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ITransactionService _transactionService;

        public NotificationController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<IActionResult> GetNotification()
        {
            var transactions = await _transactionService.AssignedTransactionsByEmployeeId();
            return Ok(new { UserNotification = "", Count = transactions.Count});
        }
    }
}
