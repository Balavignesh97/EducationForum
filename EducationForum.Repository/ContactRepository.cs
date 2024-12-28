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
                var result = await _dbContext.Subjects.Where(s => s.IsActive == true).ToListAsync();
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
                var result = await _dbContext.Grades.Where(g => g.IsActive == true).ToListAsync();
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
                var result = await _dbContext.ClassTypes.Where(ct => ct.IsActive == true).ToListAsync();
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
                var result = await _dbContext.MasterInstructiveLanguages.Where(l => l.IsActive == true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<MasterTopics>> GetTopics()
        {
            try
            {
                var result = await _dbContext.Topics.Where(t => t.IsActive == true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<MasterBoards>> GetBoards()
        {
            try
            {
                var result = await _dbContext.Boards.Where(t => t.IsActive == true).ToListAsync();
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
        public async Task<string> GetBaseForSubject(short SubjectID)
        {
            try
            {
                var check = await _dbContext.MasterSubjectBases.ToListAsync();
                var result = await _dbContext.Subjects.Where(s => s.IsActive == true && s.SubjectID == SubjectID).Include(e => e.MasterSubjectBase).FirstOrDefaultAsync();
                return result?.MasterSubjectBase?.SubjectBase ?? "";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
