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
    public class QuestionsController : Controller
    {
        private ITestService testService;
        private IQuestionService questionService;

        public QuestionsController(ITestService testService, IQuestionService questionService)
        {
            this.testService = testService;
            this.questionService = questionService;
        }

        // GET: QuestionsController
        public ActionResult Index()
        {
            return View(questionService.GetAll());
        }

        // GET: QuestionsController/Create
        public ActionResult Create()
        {
            ViewData["TestId"] = new SelectList(testService.GetAll(),
                   "TestId", "NameTest");
            return View();
        }

        // POST: QuestionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            try
            {
                questionService.Create(question);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(question);
            }
        }

        // GET: QuestionsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["TestId"] = new SelectList(testService.GetAll(),
                   "TestId", "NameTest");
            return View(questionService.Get(id));
        }

        // POST: QuestionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            try
            {
                questionService.Update(question);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(question);
            }
        }

        // GET: QuestionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(questionService.Get(id));
        }

        // POST: QuestionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Question question)
        {
            try
            {
                questionService.Delete(question.QuestionId);
                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(question);
            }
        }
    }
}
