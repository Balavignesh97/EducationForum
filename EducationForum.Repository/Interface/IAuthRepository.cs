using EducationForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<User> AuthenticateUser(string Email, string Password);
    }
}
