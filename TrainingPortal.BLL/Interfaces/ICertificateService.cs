using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainingPortal.Common.Models;

namespace TrainingPortal.BLL.Interfaces
{
    public interface ICertificateService
    {
        public byte[] CreateFilePDF(int courseId, int userId);
    }
}
