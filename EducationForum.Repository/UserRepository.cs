using EducationForum.Common;
using EducationForum.DataAccess;
using EducationForum.Domain;
using EducationForum.Repository.Interface;
using Microsoft.Data.SqlClient;
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
        public async Task<User> AddUser(User user)
        {
            User? Newuser = new User();
            try
            {

                SqlParameter param1 = new SqlParameter("@UserType", user.UserType);
                SqlParameter param2 = new SqlParameter("@Email", user.Email);
                SqlParameter param3 = new SqlParameter("@Password", user.ConfirmPassword);
                SqlParameter param4 = new SqlParameter("@FirstName", user.FirstName);
                SqlParameter param5 = new SqlParameter("@LastName", user.LastName == null ? DBNull.Value : user.LastName);
                SqlParameter param6 = new SqlParameter("@Gender", user.Gender);
                SqlParameter param7 = new SqlParameter("@Address1", user.Address1 == null ? DBNull.Value : user.Address1);
                SqlParameter param8 = new SqlParameter("@Address2", user.Address2 == null ? DBNull.Value : user.Address2);
                SqlParameter param9 = new SqlParameter("@Phone", user.Phone == null ? DBNull.Value : user.Phone);
                SqlParameter param10 = new SqlParameter("@State", user.State == null ? DBNull.Value : user.State);
                SqlParameter param11 = new SqlParameter("@City", user.City == null ? DBNull.Value : user.City);

                //var check =  _dbContext.Users.FromSqlRaw($"EXEC {SP.AddORUpdateUser} @UserType, @Email, @Password, @FirstName, @LastName, @Gender, @Address1, @Address2, @Phone, @State, @City"
                //    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

                var result = _dbContext.Users.FromSqlRaw($"EXEC {SP.AddORUpdateUser} @UserType, @Email, @Password, @FirstName, @LastName, @Gender, @Address1, @Address2, @Phone, @State, @City"
                    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11).AsEnumerable().FirstOrDefault();
                if (result != null && result.UserID > 0)
                {
                    Newuser = result;
                    return Newuser ?? new User { };
                }
                return new User { };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<MasterUserType>> GetUserType()
        {
            try
            {
                var result = await _dbContext.UserTypes.ToListAsync();
                if (result != null)
                {
                    return result;
                }
                return new List<MasterUserType> { };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
