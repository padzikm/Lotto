using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lotto.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int a = 1;
            int b = 1;
            object o1 = a;
            object o2 = b;
            if (o1.Equals(o2))
                ViewBag.msg = "tak";
            else
                ViewBag.msg = "nie";

            return View();
        }

    }
}
