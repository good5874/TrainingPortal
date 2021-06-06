using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.Common.Models;

namespace TrainingPortal.Controllers
{
    [Authorize(Roles = "Editor")]
    public class TestsController : Controller
    {
        private ITestService testService;
        private ICourseService courseService;

        public TestsController(ITestService testService, ICourseService courseService)
        {
            this.testService = testService;
            this.courseService = courseService;
        }
        // GET: TestsController
        public ActionResult Index()
        {
            return View(testService.GetAll());
        }

        // GET: TestsController/Create
        public ActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(courseService.GetAll(),
                   "CourseId", "Name");
            return View();
        }

        // POST: TestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Test test)
        {
            try
            {
                testService.Create(test);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(test);
            }
        }

        // GET: TestsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CourseId"] = new SelectList(courseService.GetAll(),
                   "CourseId", "Name");
            return View(testService.Get(id));
        }

        // POST: TestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Test test)
        {
            try
            {
                testService.Update(test);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(test);
            }
        }

        // GET: TestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(testService.Get(id));
        }

        // POST: TestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Test test)
        {
            try
            {
                testService.Delete(test.TestId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(test);
            }
        }
    }
}
