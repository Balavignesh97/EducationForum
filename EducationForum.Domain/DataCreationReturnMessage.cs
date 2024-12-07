using System.ComponentModel.DataAnnotations;

namespace EducationForum.Domain
{
    public class DataCreationReturnMessage
    {
        public int CreatedPrimaryKey { get; set; }
        public bool IscreatedSucessfully { get; set; }
        public string? ReturnMessage { get; set; }
        public string? ErrorType { get; set; }
        public string? ErrorDisplayType { get; set; }
        public string? SpinnerID { get; set; }
        public string? ButtonSubmited { get; set; }
        public string? RedirectTo { get; set; }
    }
}
