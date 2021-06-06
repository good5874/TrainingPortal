using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authentication;
        private IUserService userService;
        public AccountController(IAuthProvider authentication, IUserService userService)
        {
            this.authentication = authentication;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authentication.Login(model.Email, model.Password, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authentication.Registration(model.UserName, model.FullName, model.Email, model.Password, HttpContext);
                    authentication.Login(model.Email, model.Password, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var email = User.FindFirst("Email");
            var user = userService.Get(email.Value);

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            userProfileViewModel.UserName = user.UserName;
            userProfileViewModel.FullName = user.FullName;
            userProfileViewModel.Email = user.Email;

            return View(userProfileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var email = User.FindFirst("Email");
                    var user = userService.Get(email.Value);
                    authentication.Logout(HttpContext);

                    user.UserName = model.UserName;
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.Password = model.Password;

                    userService.Update(user);

                    authentication.Login(model.Email, model.Password, HttpContext);

                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            authentication.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
