using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var user = _userService.Get(id);
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _userService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(user);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                _userService.Update(user);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(user);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                _userService.Delete(user.UserId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(user);
            }
        }
    }
}
