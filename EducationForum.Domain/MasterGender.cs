using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class MasterGender
    {
        [Key]
        public short GenderID { get; set; }
        public string Gender { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
