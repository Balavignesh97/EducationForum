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
using System.Text.RegularExpressions;
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
        public async Task<List<EnquiryQueue>> GetEnquiryQueueData(DashboardParam param)
        {
            List<EnquiryQueue> student = new List<EnquiryQueue>();
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
                SqlParameter param12 = new SqlParameter("@SortOrder", string.IsNullOrEmpty(param.SortOrder) ? "ASC" : param.SortOrder);
                SqlParameter param13 = new SqlParameter("@StartDate", param.StartDate == null ? DBNull.Value : param.StartDate);
                SqlParameter param14 = new SqlParameter("@EndDate", param.EndDate == null ? DBNull.Value : param.EndDate);

                //var check = _dbContext.StudentEnquiry.FromSqlRaw($"EXEC {SP.GetDashboardData} @Name, @Email, @Phone, @ClassTypeID, @IsResponded, @IsOnHold, @IsRequestCallBack, @IsCallAttemptFailed, @Skip, @Take, @Orderby, @SortOrder, @StartDate, @EndDate"
                //    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

                student = await _dbContext.EnquiryQueues.FromSqlRaw($"EXEC {SP.GetDashboardData} @Name, @Email, @Phone, @ClassTypeID, @IsResponded, @IsOnHold, @IsRequestCallBack, @IsCallAttemptFailed, @Skip, @Take, @Orderby, @SortOrder, @StartDate, @EndDate"
                    , param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14).ToListAsync();

                return student;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<StudentEnquiry> GetEnquiryByID(int EnquiryID)
        {
            try
            {
                StudentEnquiry? Enquiry = new StudentEnquiry();
                //StudentEnquiry? quiry = await _dbContext.StudentEnquiry.Where(e => e.EnquiryID == EnquiryID)
                //    .Include(e => e.studentEnquiryGradeSubjectMaps).ThenInclude(g=>g.Grade).FirstOrDefaultAsync();
                var query = (from se in _dbContext.StudentEnquiry
                             join segsm in _dbContext.StudentEnquiryGradeSubjectMap on se.EnquiryID equals segsm.EnquiryID into segsmgroup
                             from segsm in segsmgroup.DefaultIfEmpty()
                             join g in _dbContext.Grades on segsm.GradeID equals g.GradeID into ggroup
                             from g in ggroup.DefaultIfEmpty()
                             join s in _dbContext.Subjects on segsm.SubjectID equals s.SubjectID into sgroup
                             from s in sgroup.DefaultIfEmpty()
                             join ct in _dbContext.ClassTypes on se.ClassTypeID equals ct.ClassTypeID into ctgroup
                             from ct in ctgroup.DefaultIfEmpty()
                             join il in _dbContext.MasterInstructiveLanguages on se.InstructiveLanguageID equals il.InstructiveLanguageID into ilgroup
                             from il in ilgroup.DefaultIfEmpty()
                             select new
                             {
                                 se,
                                 segsm,
                                 g,
                                 s,
                                 ct,
                                 il
                             }).Where(e => e.se.EnquiryID == EnquiryID);
                var result = await query.ToListAsync();

                if (result != null && result.Count > 0)
                {
                    Enquiry = result.FirstOrDefault().se;
                    if (Enquiry.ClassTypes != null)
                    {
                        Enquiry.ClassTypes.StudentEnquiry = null;
                    }
                    if (Enquiry.InstructiveLanguage != null)
                    {
                        Enquiry.InstructiveLanguage.StudentEnquiry = null;
                    }
                    if (Enquiry.studentEnquiryGradeSubjectMaps != null)
                    {
                        foreach (var item in Enquiry.studentEnquiryGradeSubjectMaps)
                        {
                            item.StudentEnquiry = null;
                            if (item.Subject != null)
                            {
                                item.Subject.StudentEnquiryGradeSubjectMaps = null;
                            }
                            if (item.Grade != null)
                            {
                                item.Grade.StudentEnquiryGradeSubjectMaps = null;
                            }
                        }
                    }

                    return Enquiry;
                }
                return new StudentEnquiry();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
