using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users {get; set;}
        public DbSet<JobOffer> offers {get; set;}
        public DbSet<JobApplication> applications {get; set;}
    }
}