using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class MasterUserType
    {
        [Key]
        public short UserTypeID { get; set; }
        public string UserType { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
