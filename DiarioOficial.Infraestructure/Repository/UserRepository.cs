using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class UserRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), IUserRepository
    {
    }
}
