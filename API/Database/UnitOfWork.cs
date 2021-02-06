using System.Threading.Tasks;
using API.Database.Repositories;
using API.Interfaces;

namespace API.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;

        }

        public IUserRepository UserRepository => new UserRepository(_db);

        public IJobApplicationRepository JobApplicationRepository => new JobApplicationRepository(_db);

        public IJobOfferRepository JobOfferRepository => new JobOfferRepository(_db);

        public async Task<bool> Complete()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _db.ChangeTracker.HasChanges();
        }
    }
}