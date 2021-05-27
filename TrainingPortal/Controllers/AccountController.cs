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
        private IAuthentication _authentication;
        private IUserService _userService;
        public AccountController(IAuthentication authentication, IUserService userService)
        {
            _authentication = authentication;
            _userService = userService;
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
                    _authentication.Login(model.Email, model.Password, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
                catch(ValidationException ex)
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
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _authentication.Registration(model.UserName, model.Email, model.Password, HttpContext);
                    _authentication.Login(model.Email, model.Password, HttpContext);
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
            _authentication.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
