using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{

    public class Grades
    {
        [Key]
        public short GradeID { get; set; }
        public string Grade { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public virtual ICollection<StudentEnquiryGradeSubjectMap>? StudentEnquiryGradeSubjectMaps { get; set; }
    }
}
