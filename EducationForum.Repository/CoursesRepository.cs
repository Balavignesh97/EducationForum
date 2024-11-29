using EducationForum.Domain;
using EducationForum.Repository.Interface;
using EducationForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EducationForum.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        protected EForumDBContext _dbContext;
        public CoursesRepository(EForumDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TemplateCourses>> GetTemplateCourseDetails()
        {
            try
            {
                var result= await _dbContext.TemplateCourses.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
