using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WorkOrderApplication.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public string RoleName { get; set; }

        public CustomAuthorizeAttribute(string RoleName)
        {
            RoleName = "AuthorizationFailed";
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        void IsUserAuthorized(AuthorizationContext filterContext) {
            var asas = filterContext;
            //if (filterContext.context == null)
            //{
            //    return;
            //}
        }

    }
}
