using EducationForum.DataAccess;
using EducationForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository.Interface
{
    public interface IContactRepository: IRepositoryBase<object>
    {

        Task<List<Subjects>> GetSubjects();
        Task<List<Grades>> GetGrades();
        Task<List<ClassTypes>> GetClassTypes();
        Task<List<Subjects>> GetSubjectsByGrade(short gradeID);
        Task<List<MasterInstructiveLanguage>> GetInstructiveLanguage();
        Task<List<MasterTopics>> GetTopics();
        Task<List<MasterBoards>> GetBoards();
        Task<string> GetBaseForSubject(short SubjectID);
    }
}
