using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;

        }


         public void Add(User user)
        {
            _db.users.Add(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.users.SingleOrDefaultAsync(m=>m.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _db.users.ToListAsync();
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }
    }
}