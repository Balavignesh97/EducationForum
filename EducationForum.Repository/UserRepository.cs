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
    public class UserRepository : RepositoryBase<object>, IUserRepository
    {
        protected EForumDBContext _dbContext;
        public UserRepository(EForumDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByID(int id)
        {
            try
            {
                User? user = await _dbContext.Users.Where(u => u.UserID == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new User();
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
