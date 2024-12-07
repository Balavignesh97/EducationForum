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
    public class SubjectRepository :RepositoryBase<object>, ISubjectRepository
    {
        protected EForumDBContext _dbContext;
        public SubjectRepository(EForumDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Subjects>> GetSubjects()
        {
            try
            {
                var result = await _dbContext.Subjects.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Grades>> GetGrades()
        {
            try
            {
                var result = await _dbContext.Grades.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<ClassTypes>> GetClassTypes()
        {
            try
            {
                var result = await _dbContext.ClassTypes.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
