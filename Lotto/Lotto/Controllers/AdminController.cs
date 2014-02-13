using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto.Infrastructure;
using Lotto.Models;
using Lotto.Filters;

namespace Lotto.Controllers
{
    [Authenticate(AdminAccess = true)]
    public class AdminController : Controller
    {
        IUserRepository userRepository;

        public AdminController(IUserRepository repo)
        {
            userRepository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }        
    }
}
