using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IContactServices
    {
        Task<List<Subjects>> GetSubjects();
        Task<List<Grades>> GetGrades();
        Task<List<ClassTypes>> GetClassTypes();
        Task<List<Subjects>> GetSubjectsByGrade(short gradeID);
        Task<List<MasterInstructiveLanguage>> GetInstructiveLanguage();
        void SubmitEnquiry(StudentEnquiry studentenquiry);
        Task<List<MasterTopics>> GetTopics();
        Task<string> GetBaseForSubject(short SubjectID);
    }
}
