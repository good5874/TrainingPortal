using Microsoft.AspNetCore.Mvc;
using System;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    public class RolesController : Controller
    {
        private IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var roles = _roleService.GetAllRoles();
            return View(roles);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var role = _roleService.GetRole(id);
            return View(role);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            try
            {
                _roleService.Create(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var role = _roleService.GetRole(id);
            return View(role);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            try
            {
                _roleService.Update(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var role = _roleService.GetRole(id);
            return View(role);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Role role)
        {
            try
            {
                _roleService.Delete(role.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
