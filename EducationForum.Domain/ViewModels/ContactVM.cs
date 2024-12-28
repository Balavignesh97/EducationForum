using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain.ViewModels
{
    public class ContactVM
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string Mobile { get; set; }
        public string Class { get; set; }
        public string subject { get; set; }
        public string choiceofclass { get; set; }
        public string board { get; set; }
        public string topic { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string instructiveLanguage { get; set; }
        public string message { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
