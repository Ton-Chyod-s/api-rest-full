using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class UserRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User> GetUserByName(string name, string password)
        {
            return await _context.User.FirstAsync(x => x.Username == name && x.PasswordHash == password);
        }
    }
}
