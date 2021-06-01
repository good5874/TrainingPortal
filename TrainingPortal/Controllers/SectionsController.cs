using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class SectionsController : Controller
    {
        private ISectionService sectionService;

        public SectionsController(ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }

        // GET: SetionsController
        public ActionResult Index()
        {
            return View(sectionService.GetAll());
        }

        // GET: SetionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Section section)
        {
            try
            {
                sectionService.Create(section);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(section);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(sectionService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Section section)
        {
            try
            {
                sectionService.Update(section);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(section);
            }
        }

        // GET: SetionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sectionService.Get(id));
        }

        // POST: SetionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Section section)
        {
            try
            {
                sectionService.Delete(section.SectionId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(section);
            }
        }
    }
}
