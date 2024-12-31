using DiarioOficial.Domain.Entities.Token;
using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class AuthTokenRepository(OfficialDiaryDbContext context) : BaseRepository<AuthToken>(context), IAuthTokenRepository
    {

    }
}
