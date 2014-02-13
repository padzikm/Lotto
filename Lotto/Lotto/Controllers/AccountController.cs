using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto.Models;
using Lotto.Infrastructure;

namespace Lotto.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository userRepository;
        private IAuthProvider authProvider;

        public AccountController(IUserRepository repo, IAuthProvider auth)
        {
            userRepository = repo;
            authProvider = auth;
        }

        public ViewResult RegisterUser()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (userRepository.AddUser(user.Name, user.Password))
                return RedirectToAction("Index", "Lotto");
            else
            {
                ModelState.AddModelError("RegisterUser", "Name already exists!");
                return View();
            }
        }

        public ViewResult LogInUser()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult LogInUser(User user)
        {
            User authUser = authProvider.Authenticate(user.Name, user.Password);  

            if (authUser != null)
            {
                HttpContext.Session["User"] = authUser;
                return RedirectToAction("Index", "Lotto");
            }
            else
            {
                ModelState.AddModelError("LoginUser", "User not found");
                return View();
            }
        }

        public ViewResult Logout()
        {
            HttpContext.Session["User"] = null;

            return View("LogInUser", new User());
        }
    }
}
