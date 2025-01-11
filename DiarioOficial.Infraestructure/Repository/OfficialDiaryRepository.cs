using DiarioOficial.Domain.Entities.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using RestSharp;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class OfficialDiaryRepository(OfficialDiaryDbContext context) : BaseRepository<OfficialDiaries>(context), IOfficialStateDiaryRepository
    {
         
    }
}
