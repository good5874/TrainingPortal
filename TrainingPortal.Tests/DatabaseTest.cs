using System;
using System.Linq;
using TrainingPortal.Common.Models;
using TrainingPortal.DAL.Interfaces;
using TrainingPortal.DAL.Repositories;
using Xunit;

namespace TrainingPortal.Tests
{
    [Collection("DatabaseTest")]
    public class DatabaseTest
    {
        IUnitOfWork unitOfWork = new UnitOfWork("Data Source=WIN-AH0B86FQ7GQ\\MSSQLSERVER2019;Initial Catalog=TrainingPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        private Section section = new Section() { Name = "nameSection" };

        [Fact]
        public void CreateAndDeleteSection()
        {
            unitOfWork.Sections.Create(section);
            var sectionTestCreate = unitOfWork.Sections.GetAll().FirstOrDefault(e => e.Name == section.Name);

            unitOfWork.Sections.Delete(sectionTestCreate.SectionId);
            var sectionTestDelete = unitOfWork.Sections.GetAll().FirstOrDefault(e => e.Name == section.Name);


            Assert.NotNull(sectionTestCreate);
            Assert.Equal(sectionTestCreate.Name, section.Name);
            Assert.Null(sectionTestDelete);
        }
    }
}
