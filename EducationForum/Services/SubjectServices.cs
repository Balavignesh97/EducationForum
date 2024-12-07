using EducationForum.Domain;
using EducationForum.Services.Interface;
using EducationForum.Repository;
using EducationForum.Repository.Interface;

namespace EducationForum.Services
{
    public class SubjectServices : ISubjectServices
    {
        public ISubjectRepository _SubjectRepository { get; set; }
        public SubjectServices(ISubjectRepository SubjectRepository)
        {
            _SubjectRepository = SubjectRepository;
        }
        public async Task<List<Subjects>> GetSubjects()
        {
            try
            {
                return await _SubjectRepository.GetSubjects();
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
                return await _SubjectRepository.GetGrades();
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
                return await _SubjectRepository.GetClassTypes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Create(StudentEnquiry studentenquiry)
        {
            _SubjectRepository.Insert(studentenquiry);
        }
        public void Create(StudentEnquiryGradeSubjectMap studentenquirygradesubjectmap)
        {
            _SubjectRepository.Insert(studentenquirygradesubjectmap);
        }
    }
}
