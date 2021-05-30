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
    public class CoursesController : Controller
    {
        private ICourseService courseService;
        private ISectionService sectionService;

        public CoursesController(ICourseService courseService, ISectionService sectionService)
        {
            this.courseService = courseService;
            this.sectionService = sectionService;
        }

        // GET: CoursesController
        public ActionResult Index()
        {
            return View(courseService.GetAll());
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            ViewData["SectionId"] = new SelectList(sectionService.GetAll(),
                "SectionId", "Name");
            return View();
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                courseService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(course);
            }
        }

        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["SectionId"] = new SelectList(sectionService.GetAll(),
                "SectionId", "Name");
            return View(courseService.Get(id));
        }

        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            try
            {
                courseService.Update(course);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(course);
            }
        }

        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseService.Get(id));
        }

        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course course)
        {
            try
            {
                courseService.Delete(course.CourseId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(course);
            }
        }
    }
}
