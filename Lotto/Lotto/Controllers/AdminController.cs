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
        IStatisticRepository statRepository;

        public AdminController(IUserRepository userRepo, IStatisticRepository statRepo)
        {
            userRepository = userRepo;
            statRepository = statRepo;
        }

        public ViewResult Index()
        {
            ViewBag.id = "nic";
            return View();
        }

        public ViewResult VerifyUsers()
        {
            IEnumerable<User> inActiveUsers = userRepository.GetAllInActiveUsers();

            return View(inActiveUsers);
        }

        public ActionResult ActivateUser(int userID)
        {
            User user = userRepository.GetUser(userID);

            if (user != null)
            {
                user.IsActive = true;
                userRepository.SaveUser(user);
                ViewBag.Success = "Operacja wykonana pomyslnie!";
            }

            return RedirectToAction("VerifyUsers");
        }

        public ActionResult DeleteUser(int userID)
        {
            userRepository.DeleteUser(userID);
            ViewBag.Success = "Operacja wykonana pomyslnie!";

            return RedirectToAction("VerifyUsers");
        }

        public ActionResult AddLottoResultManually()
        {
            return View(new Statistic());
        }

        [HttpPost]
        public ActionResult AddLottoResultManually(Statistic stat)
        {
            if (!ModelState.IsValid)
                return View();

            statRepository.AddStatistic(stat);
            ViewBag.Success = "Operacja wykonana pomyslnie!";

            return View();
        }

        public ActionResult AddLottoResultAuto()
        {
            return View(new DateTime());
        }

        [HttpPost]
        public ActionResult AddLottoResultAuto(DateTime date)
        {
            ViewBag.Success = "Operacja wykonana pomyslnie!";

            return View();
        }
    }
}
