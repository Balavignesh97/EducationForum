using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class MasterState
    {
        [Key]
        public short StateID { get; set; }
        public string StateName { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
