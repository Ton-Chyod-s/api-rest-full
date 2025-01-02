using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class UserRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> GetUserByName(string name, string password)
        {
            var nameUser = await _context.User.FirstOrDefaultAsync(x => x.Username == name && x.PasswordHash == password);

            if (nameUser is null)
                return null;

            return nameUser;
        }
    }
}
