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
    public class LessonsController : Controller
    {
        private ILessonService lessonService;
        private ICourseService courseService;

        public LessonsController(ILessonService lessonService, ICourseService courseService)
        {
            this.lessonService = lessonService;
            this.courseService = courseService;
        }

        // GET: LessonsController
        public ActionResult Index()
        {
            return View(lessonService.GetAll());
        }

        // GET: LessonsController/Create
        public ActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(courseService.GetAll(),
                   "CourseId", "Name");
            return View();
        }

        // POST: LessonsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lesson lesson)
        {
            try
            {
                lessonService.Create(lesson);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(lesson);
            }
        }

        // GET: LessonsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CourseId"] = new SelectList(courseService.GetAll(),
                   "CourseId", "Name");
            return View(lessonService.Get(id));
        }

        // POST: LessonsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lesson lesson)
        {
            try
            {
                lessonService.Update(lesson);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(lesson);
            }
        }

        // GET: LessonsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(lessonService.Get(id));
        }

        // POST: LessonsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Lesson lesson)
        {
            try
            {
                lessonService.Delete(lesson.LessonId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(lesson);
            }
        }
    }
}
