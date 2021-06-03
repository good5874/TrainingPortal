using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainingPortal.BLL.Infrastructure;
using TrainingPortal.BLL.Interfaces;
using TrainingPortal.DAL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class CertificateService : ICertificateService
    {
        IUnitOfWork Database { get; set; }

        public CertificateService(IUnitOfWork db)
        {
            Database = db;
        }

        public byte[] CreateFilePDF(int courseId, int userId)
        {
            var certificate = Database.Certificates.Get(courseId, userId);

            if (certificate == null)
            {
                throw new ValidationException("Сертификата не существует", "");
            }

            SautinSoft.PdfMetamorphosis p = new SautinSoft.PdfMetamorphosis();

            string htmlString = $"This certificate confirms that {certificate.FullName} has completed the {certificate.NameCourse} course.";
            byte[] pdfBytes = p.TextToPdfConvertStringToByte(htmlString);

            return pdfBytes;
        }
    }
}
