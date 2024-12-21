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
        public Task<List<EnquiryQueue>> GetEnquiryQueueData(DashboardParam param)
        {
            try
            {
                return _dashboardepository.GetEnquiryQueueData(param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Task<StudentEnquiry> GetEnquiryByID(int EnquiryID)
        {
            try
            {
                return _dashboardepository.GetEnquiryByID(EnquiryID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
