using EducationForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByID(int id);
        Task<User> AddUser(User user);
        Task<List<MasterUserType>> GetUserType();
    }
}
