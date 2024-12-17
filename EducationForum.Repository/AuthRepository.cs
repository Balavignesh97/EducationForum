using EducationForum.DataAccess;
using EducationForum.Domain;
using EducationForum.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository
{
    public class AuthRepository : IAuthRepository
    {
        protected EForumDBContext _dbContext;
        public AuthRepository(EForumDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> AuthenticateUser(string Email, string Password)
        {
            try
            {
                var user = await _dbContext.Users.Where(u => u.Email == Email && u.Password == EForumDBContext.Encrypt(Password)).FirstOrDefaultAsync();
                if (user != null && user.UserID > 0)
                {
                    return user;
                }
                else
                {
                    return new User { };
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
