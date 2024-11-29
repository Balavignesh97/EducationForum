using EducationForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository.Interface
{
    public interface ICoursesRepository
    {
        Task<List<TemplateCourses>> GetTemplateCourseDetails();
    }
}
