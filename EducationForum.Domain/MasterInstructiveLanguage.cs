using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class MasterInstructiveLanguage
    {
        public short InstructiveLanguageID { get; set; }
        public string Language { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; } 
    }
}
