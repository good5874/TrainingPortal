using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingPortal.Common.Models
{
    public class Section
    {
        public Section()
        {

        }

        public Section(int Sectionid, string Name)
        {
            this.SectionId = SectionId;
            this.Name = Name;
        }

        public int SectionId { get; set; }
        public string Name { get; set; }
    }
}
