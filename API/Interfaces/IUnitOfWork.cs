using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        IJobApplicationRepository JobApplicationRepository {get;}
        IJobOfferRepository JobOfferRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}