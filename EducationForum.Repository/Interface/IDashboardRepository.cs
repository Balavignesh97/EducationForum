using EducationForum.Domain;
using EducationForum.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.Repository.Interface
{
    public interface IDashboardRepository
    {
        Task<List<EnquiryQueue>> GetEnquiryQueueData(DashboardParam param);
        Task<StudentEnquiry> GetEnquiryByID(int EnquiryID);
        Task<StudentEnquiry> UpdateEnquiryQueue(EnquiryQueue enquiry);
    }
}
