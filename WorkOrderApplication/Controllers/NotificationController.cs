using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrderApplication.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult GetNotification()
        {
            //var userId = _userManager.GetUserId(HttpContext.User);
            //var notification = _notificationRepository.GetUserNotifications(userId);
            int count = 0;
            count = count + 1;
            return Ok(new { UserNotification = "", Count = count });
        }
    }
}
