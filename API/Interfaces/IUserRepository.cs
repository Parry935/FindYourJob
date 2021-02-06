using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Add(User User);
         void Update(User User);
         Task<IEnumerable<User>> GetUsersAsync();
         Task<User> GetUserByIdAsync(int id);
          Task<User> GetUserByEmailAsync(string email);
    }
}