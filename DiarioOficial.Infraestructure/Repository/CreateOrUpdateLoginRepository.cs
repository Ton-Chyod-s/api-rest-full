using DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.Domain.Entities.Token;
using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class CreateOrUpdateLoginRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), ICreateOrUpdateLoginRepository 
    {
        
    }

}
