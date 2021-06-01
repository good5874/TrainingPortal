using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.BLL.Models;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork db)
        {
            Database = db;
        }

        public void Create(Test test)
        {
            Database.Tests.Create(test);
        }

        public void Delete(int id)
        {
            Database.Tests.Delete(id);
        }

        public Test Get(int id)
        {
            return Database.Tests.Get(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return Database.Tests.GetAll();
        }

        public void Update(Test test)
        {
            Database.Tests.Update(test);
        }

        public IEnumerable<Test> GetTests(int courseId)
        {
            return Database.Tests.GetTests(courseId);
        }

        public ValidatedTestDTO CheckTest(int testId, List<string> results, ClaimsPrincipal userClaim)
        {
            ValidatedTestDTO validatedTestDTO = new ValidatedTestDTO();

            var test = Database.Tests.Get(testId);
          
            var questions = Database.Questions.GetQuestions(test.TestId).ToList();

            if (questions.Count != results.Count)
            {
                throw new ValidationException("Ошибка, попробуйте пройти тест позже", "");
            }

            List<(Question, string, bool)> validatedQuestions = new List<(Question, string, bool)>();
            int rightQuestions = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Answer == results[i])
                {
                    rightQuestions++;
                    validatedQuestions.Add((questions[i], results[i], true));
                }
                else
                {
                    validatedQuestions.Add((questions[i], results[i], false));
                }
            }

            double percent = (double)rightQuestions / questions.Count * 100;
            var result = $"Тест пройден на {Math.Round(percent, 2)}%";

            validatedTestDTO.NameTest = test.NameTest;
            validatedTestDTO.Result = result;
            validatedTestDTO.ValidatedQuestions = validatedQuestions;

            SaveResultTest(rightQuestions, questions.Count, userClaim, test);

            return validatedTestDTO;
        }

        private void SaveResultTest(int rightQuestions, int allQuestions, ClaimsPrincipal userClaim, Test test)
        {
            var email = userClaim.FindFirst("Email");
            var user = Database.Users.Get(email.Value);

            UserTests userTestsTemp = new UserTests();
            userTestsTemp.TestId = test.TestId;
            userTestsTemp.UserId = user.UserId;

            if (rightQuestions == allQuestions)
            {
                userTestsTemp.IsFinish = true;
            }
            else
            {
                userTestsTemp.IsFinish = false;
            }

            var userTests = Database.UserTests.Get(userTestsTemp.TestId, userTestsTemp.UserId);

            if (userTests == null)
            {
                Database.UserTests.Create(userTestsTemp);
            }
            else
            {
                if (userTests.IsFinish == false && userTestsTemp.IsFinish == true)
                {
                    Database.UserTests.Update(userTestsTemp);
                }
            }
        }
    }
}
