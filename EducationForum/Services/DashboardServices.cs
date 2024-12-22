using EducationForum.Domain;
using EducationForum.Domain.ViewModels;
using EducationForum.Repository.Interface;
using EducationForum.Services.Interface;

namespace EducationForum.Services
{
    public class DashboardServices : IDashboardServices
    {
        public IDashboardRepository _dashboardepository;
        public DashboardServices(IDashboardRepository dashboardepository)
        {
            _dashboardepository = dashboardepository;
        }
        public async Task<List<EnquiryQueue>> GetEnquiryQueueData(DashboardParam param)
        {
            try
            {
                return await _dashboardepository.GetEnquiryQueueData(param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<StudentEnquiry> GetEnquiryByID(int EnquiryID)
        {
            try
            {
                return await _dashboardepository.GetEnquiryByID(EnquiryID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<StudentEnquiry> UpdateEnquiryQueue(EnquiryQueue enquiry)
        {
            try
            {
                return await _dashboardepository.UpdateEnquiryQueue(enquiry);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
