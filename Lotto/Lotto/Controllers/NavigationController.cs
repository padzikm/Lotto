using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lotto.Controllers
{
    public class NavigationController : Controller
    {        
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            return PartialView();
        }

        public PartialViewResult AdminMenu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            return PartialView();
        }
    }
}
