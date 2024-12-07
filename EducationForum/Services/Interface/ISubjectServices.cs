using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface ISubjectServices
    {
        Task<List<Subjects>> GetSubjects();
        Task<List<Grades>> GetGrades();
        Task<List<ClassTypes>> GetClassTypes();

        public void Create(StudentEnquiry studentenquiry);
        public void Create(StudentEnquiryGradeSubjectMap studentenquirygradesubjectmap);
    }
}
