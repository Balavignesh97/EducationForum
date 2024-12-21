using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain
{

    public class ClassTypes
    {
        [Key]
        public short ClassTypeID { get; set; }
        public string ClassType { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateAdded { get; set; }
        public virtual StudentEnquiry? StudentEnquiry { get; set; }
    }
}
