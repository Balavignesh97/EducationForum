using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class Contact
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string Mobile { get; set; }
        public string Class { get; set; }
        public string subject { get; set; }
        public string choiceofclass { get; set; }
        public string message { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
