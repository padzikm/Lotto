using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto.Filters;

namespace Lotto.Controllers
{
    [Authenticate(AdminAccess = false)]
    public class LottoController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

    }
}
