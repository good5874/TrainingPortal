using Microsoft.AspNetCore.Mvc;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    public class UserRolesController : Controller
    {
        private IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        // GET: UserRolesController
        public ActionResult Index()
        {
            var userRoles = _userRolesService.GetAll();
            return View(userRoles);
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
                _userRolesService.Create(userRole.UserId, userRole.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
                _userRolesService.Delete(userRole.UserId, userRole.RoleId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
