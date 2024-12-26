using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class MasterBoards
    {
        [Key]
        public short BoardID { get; set; }
        public string Board { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual StudentEnquiry? Enquiry { get; set; }
    }
}
