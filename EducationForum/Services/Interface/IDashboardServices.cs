using EducationForum.Domain.ViewModels;
using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IDashboardServices
    {
        Task<List<StudentEnquiry>> GetDashboardData(DashboardParam param);
    }
}
