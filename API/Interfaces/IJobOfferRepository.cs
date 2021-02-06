using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IJobOfferRepository
    {
        void Add(JobOffer offer);
        void Update(JobOffer offer);
         Task<IEnumerable<JobOffer>> GetOffersAsync();
         Task<JobOffer> GetOfferByIdAsync(int id);
    }
}