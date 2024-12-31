using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using OneOf;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class CreateOrUpdateLoginRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), ICreateOrUpdateLoginRepository 
    {
        public async Task<OneOf<bool, BaseError>> AddOrUpdateUser(string name, string email)
        {

            throw new NotImplementedException();
        }
    }

}

