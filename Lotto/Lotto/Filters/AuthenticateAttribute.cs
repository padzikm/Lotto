using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto.Controllers;
using Lotto.Models;

namespace Lotto.Filters
{
    public class AuthenticateAttribute : FilterAttribute, IActionFilter
    {
        public bool AdminAccess { get; set; }        

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            User user = (User)filterContext.HttpContext.Session["User"];

            if (user == null || !user.IsActive || (AdminAccess && !user.IsAdmin))            
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "LogInUser" }));                            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}