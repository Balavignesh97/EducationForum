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
        public Task<List<StudentEnquiry>> GetDashboardData(DashboardParam param)
        {
            try
            {
                return _dashboardepository.GetDashboardData(param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
