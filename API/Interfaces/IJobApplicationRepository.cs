using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IJobApplicationRepository
    {
        void Add(JobApplication application);
         void Update(JobApplication application);
         Task<IEnumerable<JobApplication>> GetApplicationsAsync();
         Task<JobApplication> GetApplicationByIdAsync(int id);
    }
}