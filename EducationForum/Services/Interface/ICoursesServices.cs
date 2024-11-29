using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface ICoursesServices
    {
        Task<List<TemplateCourses>> GetTemplateCourseDetails();
    }
}
