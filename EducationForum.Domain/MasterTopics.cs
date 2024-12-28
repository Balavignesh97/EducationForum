using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{
    public class MasterTopics
    {
        [Key]
        public short TopicsID { get; set; }
        public string Topics { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual StudentEnquiry? StudentEnquiry { get; set; }
    }
}
