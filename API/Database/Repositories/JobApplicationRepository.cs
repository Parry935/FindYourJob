using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly AppDbContext _db;
        public JobApplicationRepository(AppDbContext db)
        {
            _db = db;

        }

        public void Add(JobApplication application)
        {
            _db.applications.Add(application);
        }

        public async Task<JobApplication> GetApplicationByIdAsync(int id)
        {
             return await _db.applications.FindAsync(id);
        }

        public async Task<IEnumerable<JobApplication>> GetApplicationsAsync()
        {
            return await _db.applications.ToListAsync();
        }

        public void Update(JobApplication application)
        {
            _db.Entry(application).State = EntityState.Modified;
        }
    }
}