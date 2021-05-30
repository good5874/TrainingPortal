using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    public class UserRolesController : Controller
    {
        private IUserRolesService userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            this.userRolesService = userRolesService;
        }

        // GET: UserRolesController
        public ActionResult Index()
        {
            return View(userRolesService.GetAll());
        }

        // GET: UserRolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRole userRole)
        {
            try
            {
                userRolesService.Create(userRole.UserId, userRole.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userRole);
            }
        }

        // GET: UserRolesController/Delete/5
        public ActionResult Delete(int userId, int roleId)
        {
            return View(new UserRole(userId, roleId));
        }

        // POST: UserRolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserRole userRole)
        {
            try
            {
                userRolesService.Delete(userRole.UserId, userRole.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userRole);
            }
        }
    }
}
