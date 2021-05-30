using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public int SectionId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
