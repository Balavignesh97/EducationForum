using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{

    public class StudentEnquiry
    {
        [Key]
        public int EnquiryID { get; set; }
        public int? ResponderID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public short? ClassTypeID { get; set; }
        public short? InstructiveLanguageID { get; set; }
        public string? EnquirerNote { get; set; }
        public string? ResponderNote { get; set; }
        public bool IsResponded { get; set; }
        public bool IsOnHold { get; set; }
        public bool IsRequestCallBack { get; set; }
        public bool IsCallAttemptFailed { get; set; }
        public DateTime? RespondedOn { get; set; }
        public DateTime? CallBackDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public virtual ICollection<StudentEnquiryGradeSubjectMap> studentEnquiryGradeSubjectMaps { get; set; }
        public string? ClassType { get; set; }
        public int TotalCount { get; set; }
    }
}
