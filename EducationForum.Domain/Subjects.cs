using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    
    public class Subjects
    {
        [Key]
        public short SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public short SubjectBaseID { get; set; }
        public virtual ICollection<StudentEnquiryGradeSubjectMap>? StudentEnquiryGradeSubjectMaps { get; set; }
        public virtual MasterSubjectBase? MasterSubjectBase { get; set; }
    }
}
