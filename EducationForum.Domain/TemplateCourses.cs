using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class TemplateCourses
    {
        [Key]
        public int CourseTemplateID { get; set; }
        public string? CourseHeading { get; set; }
        public string? ImagePath { get; set; }
        public short SubjectID { get; set; }
        public short GradeFrom { get; set; }
        public short GradeTo { get; set; }
        public bool IsGroupClassAvailable { get; set; }
        public short? MaxStudentForGroupClass { get; set; }
        public bool IsIndividualClassAvailable { get; set; }
        public short? InstructorID { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? DeactivatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
