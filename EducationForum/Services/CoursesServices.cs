using EducationForum.Domain;
using EducationForum.Services.Interface;
using EducationForum.Repository;
using EducationForum.Repository.Interface;

namespace EducationForum.Services
{
    public class CoursesServices : ICoursesServices
    {
        public ICoursesRepository _coursesRepository { get; set; }
        public CoursesServices(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public async Task<List<TemplateCourses>> GetTemplateCourseDetails()
        {
            try
            {
                return await _coursesRepository.GetTemplateCourseDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
