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
    public class ContactRepository : RepositoryBase<object>, IContactRepository
    {
        protected EForumDBContext _dbContext;
        public ContactRepository(EForumDBContext dbContext) : base(dbContext)
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
        public async Task<List<MasterInstructiveLanguage>> GetInstructiveLanguage()
        {
            try
            {
                var result = await _dbContext.MasterInstructiveLanguages.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Subjects>> GetSubjectsByGrade(short gradeID)
        {
            List<Subjects> subjects = new List<Subjects>();
            try
            {
                var query = (from s in _dbContext.Subjects
                             join gsm in _dbContext.GradeSubjectMaps on s.SubjectID equals gsm.SubjectID
                             where gsm.GradeID == gradeID
                             select s).OrderBy(s => s.SubjectName);
                var result = await query.ToListAsync();
                if (result != null)
                {
                    subjects = result;
                }
                return subjects;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
