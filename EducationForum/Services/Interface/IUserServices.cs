using EducationForum.Domain;

namespace EducationForum.Services.Interface
{
    public interface IUserServices
    {
        Task<User> GetUserByID(int ID);
    }
}
