using EducationForum.Domain.ViewModels;
using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IDashboardServices
    {
        Task<List<EnquiryQueue>> GetEnquiryQueueData(DashboardParam param);
        Task<StudentEnquiry> GetEnquiryByID(int EnquiryID);
        Task<StudentEnquiry> UpdateEnquiryQueue(EnquiryQueue enquiry);
    }
}
