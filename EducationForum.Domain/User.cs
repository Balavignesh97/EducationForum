using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationForum.Domain
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserCode { get; set; } = string.Empty;
        public Guid? UserGUID { get; set; }
        public short UserType { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] Password { get; set; } = Array.Empty<byte>();
        public string? UserImage { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public short? Gender { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Phone { get; set; }
        public short? State { get; set; }
        public string? City { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DeactivatedDate { get; set; }
        public int? DeactivatedBy { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? LockedDate { get; set; }
        public int? LockedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? LoginAttemptCount { get; set; }
        public bool? IsTwoFactorAuthentication { get; set; }

        [NotMapped]
        public string? ImageName { get; set; } = string.Empty;
        [NotMapped]
        public string? ConfirmPassword { get; set; } = string.Empty;
    }

}
