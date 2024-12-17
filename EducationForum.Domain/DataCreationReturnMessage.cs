using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class DataCreationReturnMessage
    {
        public int CreatedPrimaryKey { get; set; }
        public bool IscreatedSucessfully { get; set; }
        public string ReturnMessage { get; set; }=string.Empty;
        public string ErrorType { get; set; } = string.Empty;
        public string ErrorDisplayType { get; set; } = string.Empty;
        public string SpinnerID { get; set; } = string.Empty;
        public string ButtonID { get; set; } = string.Empty;
        public string ButtonSubmited { get; set; } = string.Empty;
        public string RedirectTo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
    }
}
