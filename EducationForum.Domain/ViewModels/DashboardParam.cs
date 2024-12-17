namespace EducationForum.Domain.ViewModels
{
    public class DashboardParam
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public byte ClassTypeID { get; set; } = 0;
        public bool? IsResponded { get; set; } = null;
        public bool? IsOnHold { get; set; } = null;
        public bool? IsRequestCallBack { get; set; } = null;
        public bool? IsCallAttemptFailed { get; set; } = null;
        public int Skip { get; set; }
        public int Take { get; set; }
        public string? Orderby { get; set; } = null;
        public string SortOrder { get; set; } = "ASC";
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
    }
}
