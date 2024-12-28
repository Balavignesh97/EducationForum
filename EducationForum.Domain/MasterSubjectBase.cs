using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class MasterSubjectBase
    {
        [Key]
        public short SubjectBaseID { get; set; }
        public string SubjectBase { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual Subjects? Subject { get; set; }
    }
}
