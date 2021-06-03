using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using TrainingPortal.Models;
using Microsoft.AspNetCore.Identity;
using TrainingPortal.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using TrainingPortal.BLL.Infrastructure;

namespace TrainingPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private IUserService userService;
        private ICourseService courseService;
        private ISectionService sectionService;
        private ILessonService lessonService;
        private ITestService testService;
        private IQuestionService questionService;
        private ICertificateService certificateService;

        public HomeController(ILogger<HomeController> logger, ICourseService courseService, ILessonService lessonService,
            ITestService testService, IQuestionService questionService, ISectionService sectionService, IUserService userService,
            ICertificateService certificateService)
        {
            this.logger = logger;
            this.courseService = courseService;
            this.lessonService = lessonService;
            this.testService = testService;
            this.questionService = questionService;
            this.sectionService = sectionService;
            this.userService = userService;
            this.certificateService = certificateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Courses(int? SectionId)
        {
            if (SectionId == null)
            {
                return View(courseService.GetAll());
            }
            return View(courseService.GetCourse(SectionId.Value));
        }

        [Authorize]
        public IActionResult MyCourses()
        {
            var email = User.FindFirst("Email");
            var user = userService.Get(email.Value);

            return View(courseService.GetFinishedCourses(user.UserId));
        }

        public IActionResult Sections()
        {
            return View(sectionService.GetAll());
        }

        [Authorize]
        public IActionResult Course(int id)
        {
            var course = courseService.Get(id);

            if (course != null)
            {
                CourseViewModel courseView = new CourseViewModel();

                courseView.CourseId = course.CourseId;
                courseView.Name = course.Name;
                courseView.Description = course.Description;
                courseView.TargetAudience = course.TargetAudience;

                courseView.Lessons = lessonService.GetLessons(course.CourseId);
                courseView.Tests = testService.GetTests(course.CourseId);

                return View(courseView);
            }

            return View(nameof(Index));
        }

        [Authorize]
        public IActionResult Lessons(int id)
        {
            var lesson = lessonService.Get(id);

            if (lesson != null)
            {
                var course = courseService.Get(lesson.CourseId);

                LessonViewModel lessonView = new LessonViewModel();

                lessonView.NameLesson = lesson.NameLesson;
                lessonView.Material = lesson.Material;
                lessonView.NameCourse = course.Name;

                return View(lessonView);
            }

            return View(nameof(Index));
        }

        [Authorize]
        public IActionResult Tests(int id)
        {
            var test = testService.Get(id);

            if (test != null)
            {
                var course = courseService.Get(test.CourseId);

                TestViewModel testView = new TestViewModel();

                testView.NameCourse = course.Name;
                testView.TestId = test.TestId;
                testView.NameTest = test.NameTest;
                testView.Questions = questionService.GetQuestions(test.TestId);

                return View(testView);
            }

            return View(nameof(Courses));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Result(int TestId, List<string> results)
        {
            var test = testService.Get(TestId);

            ResultTestViewModel resultTest = new ResultTestViewModel();
            try
            {
                resultTest.Test = testService.CheckTest(test.TestId, results, User);
                resultTest.Course = courseService.CheckCourse(test.CourseId, User);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(nameof(Courses));
            }

            return View(resultTest);
        }

        [Authorize]
        public IActionResult GetCertificate(int courseId)
        {
            var course = courseService.Get(courseId);
            course = null;
            var email = User.FindFirst("Email");
            var user = userService.Get(email.Value);

            if (course == null || user == null)
            {
                return View(nameof(Index));
            }

            try
            {
                string file_type = "application/pdf";
                string file_name = "certificate.pdf";
                return File(certificateService.CreateFilePDF(course.CourseId, user.UserId), file_type, file_name);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(nameof(Index));
            }
        }


        [Authorize]
        public IActionResult TestAut()
        {
            string str = "";
            foreach (var claim in User.Claims.ToList())
            {
                str += claim.Value + "\n";
            }
            return Content(str);
        }

        [Authorize(Roles = "Admin, Editor")]
        public IActionResult TestRole()
        {
            string str = "";
            foreach (var claim in User.Claims.ToList())
            {
                str += claim.Value + "\n";
            }
            return Content(str);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
