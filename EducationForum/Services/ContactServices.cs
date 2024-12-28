using EducationForum.Domain;
using EducationForum.Services.Interface;
using EducationForum.Repository;
using EducationForum.Repository.Interface;

namespace EducationForum.Services
{
    public class ContactServices : IContactServices
    {
        public IContactRepository _contactRepository { get; set; }
        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<Subjects>> GetSubjects()
        {
            try
            {
                return await _contactRepository.GetSubjects();
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
                return await _contactRepository.GetGrades();
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
                return await _contactRepository.GetClassTypes();
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
                return await _contactRepository.GetInstructiveLanguage();
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
                return await _contactRepository.GetTopics();
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
                return await _contactRepository.GetBoards();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SubmitEnquiry(StudentEnquiry studentenquiry)
        {
            _contactRepository.Insert(studentenquiry);
        }

        public async Task<List<Subjects>> GetSubjectsByGrade(short gradeID)
        {
            return await _contactRepository.GetSubjectsByGrade(gradeID);
        }
        public async Task<string> GetBaseForSubject(short SubjectID)
        {
            return await _contactRepository.GetBaseForSubject(SubjectID);
        }


    }
}
