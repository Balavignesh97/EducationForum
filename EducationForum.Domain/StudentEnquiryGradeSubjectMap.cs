using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{

    public class StudentEnquiryGradeSubjectMap
    {
        [Key]
        public int StudentEnquiryClassMap { get; set; }
        public int EnquiryID { get; set; }
        public short GradeID { get; set; }
        public short SubjectID { get; set; }
        public DateTime? DateAdded { get; set; }
        public virtual StudentEnquiry StudentEnquiry { get; set; }
    }
}
