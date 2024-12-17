using EducationForum.Common;
using EducationForum.DataAccess;
using EducationForum.Domain;
using EducationForum.Domain.ViewModels;
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
    public class DashboardRepository : IDashboardRepository
    {
        protected EForumDBContext _dbContext;
        public DashboardRepository(EForumDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentEnquiry>> GetDashboardData(DashboardParam param)
        {
            List<StudentEnquiry> student = new List<StudentEnquiry>();
            try
            {
                SqlParameter param1 = new SqlParameter("@Name", param.Name);
                SqlParameter param2 = new SqlParameter("@Email", param.Email);
                SqlParameter param3 = new SqlParameter("@Phone", param.Phone);
                SqlParameter param4 = new SqlParameter("@ClassTypeID", param.ClassTypeID);
                SqlParameter param5 = new SqlParameter("@IsResponded", param.IsResponded == null ? DBNull.Value : param.IsResponded);
                SqlParameter param6 = new SqlParameter("@IsOnHold", param.IsOnHold == null ? DBNull.Value : param.IsOnHold);
                SqlParameter param7 = new SqlParameter("@IsRequestCallBack", param.IsRequestCallBack == null ? DBNull.Value : param.IsRequestCallBack);
                SqlParameter param8 = new SqlParameter("@IsCallAttemptFailed", param.IsCallAttemptFailed == null ? DBNull.Value : param.IsCallAttemptFailed);
                SqlParameter param9 = new SqlParameter("@Skip", param.Skip);
                SqlParameter param10 = new SqlParameter("@Take", param.Take);
                SqlParameter param11 = new SqlParameter("@Orderby", param.Orderby ?? "EnquiryID");
                SqlParameter param12 = new SqlParameter("@SortOrder", param.SortOrder ?? "ASC");
                SqlParameter param13 = new SqlParameter("@StartDate", param.StartDate == null ? DBNull.Value : param.StartDate);
                SqlParameter param14 = new SqlParameter("@EndDate", param.EndDate == null ? DBNull.Value : param.EndDate);

                //var check = _dbContext.StudentEnquiry.FromSqlRaw($"EXEC {SP.GetDashboardData}"
                //    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

                student = await _dbContext.StudentEnquiry.FromSqlRaw($"EXEC {SP.GetDashboardData} @Name, @Email, @Phone, @ClassTypeID, @IsResponded, @IsOnHold, @IsRequestCallBack, @IsCallAttemptFailed, @Skip, @Take, @Orderby, @SortOrder, @StartDate, @EndDate"
                    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14).ToListAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
