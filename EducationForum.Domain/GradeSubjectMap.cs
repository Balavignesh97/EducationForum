using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class GradeSubjectMap
    {
        public int GradeSubjectMapID { get; set; }
        public short GradeID { get; set; }
        public short SubjectID { get; set; }
        public bool IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
