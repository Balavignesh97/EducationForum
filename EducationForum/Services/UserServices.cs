using EducationForum.Domain;
using EducationForum.Services.Interface;

namespace EducationForum.Services
{
    public class UserServices : IUserServices
    {
        public Task<User> GetUserByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
