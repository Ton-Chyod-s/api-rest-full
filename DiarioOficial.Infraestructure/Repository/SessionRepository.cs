using DiarioOficial.Domain.Entities.BaseEntity;
using DiarioOficial.Domain.Entities.OfficialStateDiary;
using DiarioOficial.Domain.Entities.Session;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class SessionRepository(OfficialDiaryDbContext context) : BaseRepository<Session>(context), ISessionRepository
    {

    }
}
