using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Domain.ViewModels
{
    public class UserVM
    {
        public short UserTypeDD { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public short? Gender { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Phone { get; set; }
        public string? State { get; set; }
        public string? city { get; set; }
        public string? ConfirmPassword { get; set; } = string.Empty;
        public string? ImageName { get; set; } = string.Empty;
    }
}
