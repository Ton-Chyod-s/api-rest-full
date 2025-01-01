using DiarioOficial.CrossCutting.DTOs.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.Errors;
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
        public async Task<OneOf<bool, BaseError>> AddOrUpdateUser(CreateOrUpdateLoginDTO createOrUpdateLoginDTO)
        {
            var token = await _context.AuthToken
                .AddAsync(new AuthToken(createOrUpdateLoginDTO.BearerToken!));

            var findUser = await _context.User.FirstOrDefaultAsync(x => x.Username == createOrUpdateLoginDTO.Username);

            if (findUser is null)
            {
                var newUser = new User
                (
                    createOrUpdateLoginDTO.Username,
                    createOrUpdateLoginDTO.PasswordHash,
                    createOrUpdateLoginDTO.Email,
                    createOrUpdateLoginDTO.IsActive,
                    createOrUpdateLoginDTO.Roles
                );
                await _context.User.AddAsync(newUser);
            } else
            {
                findUser.UpdateUser
                (
                    createOrUpdateLoginDTO.Username,
                    createOrUpdateLoginDTO.Email,
                    createOrUpdateLoginDTO.IsActive,
                    createOrUpdateLoginDTO.Roles
                );
                _context.User.Update(findUser);
            }
            
            await _context.SaveChangesAsync();
            
            return true;
        }
    }

}
