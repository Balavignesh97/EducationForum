using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IUserServices
    {
        Task<User> GetUserByID(int ID);
        Task<User> AddUser(User user);
        Task<List<MasterUserType>> GetUserType();
    }
}
