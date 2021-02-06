using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Repositories
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly AppDbContext _db;
        public JobOfferRepository(AppDbContext db)
        {
            _db = db;

        }

        public void Add(JobOffer offer)
        {
            _db.offers.Add(offer);
        }


        public async Task<JobOffer> GetOfferByIdAsync(int id)
        {
            return await _db.offers.FindAsync(id);
        }

        public async Task<IEnumerable<JobOffer>> GetOffersAsync()
        {
           return await _db.offers.ToListAsync();
        }

        public void Update(JobOffer offer)
        {
            _db.Entry(offer).State = EntityState.Modified;
        }
    }
}