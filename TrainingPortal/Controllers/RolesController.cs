using Microsoft.AspNetCore.Mvc;
using System;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    public class RolesController : Controller
    {
        private IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(roleService.GetAllRoles());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View(roleService.GetRole(id));
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
                roleService.Create(role);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(role);
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(roleService.GetRole(id));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            try
            {
                roleService.Update(role);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(role);
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(roleService.GetRole(id));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Role role)
        {
            try
            {
                roleService.Delete(role.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(role);
            }
        }
    }
}
