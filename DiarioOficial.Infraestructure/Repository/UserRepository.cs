using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Enums.User;
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
    internal class UserRepository(OfficialDiaryDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> GetUserByName(string name, string password)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserName == name && x.PassWordHash == password);
        }

        public async Task<bool> AddUser(ResquestAddOrUpdateLoginDTO content)
        {
            var findUser = new User(content.UserName,content.Password);
            await _context.User.AddAsync(findUser);

            return await _context.SaveChangesAsync() < 0;
        }

        public async Task<OneOf<bool, BaseError>> UpdateUser(ResquestAddOrUpdateLoginDTO content)
        {
            var findUser = await _context.User.FirstOrDefaultAsync(x => x.UserName == content.UserName);

            if (findUser is not null)
            {
                findUser.UpdateUser(content.UserName, true, UserEnum.Admin);
                _context.User.Update(findUser);
            }

            return await _context.SaveChangesAsync() < 0;
        }

        public async Task<OneOf<bool, BaseError>> AddOrUpdateToken(string bearerToken, long userId)
        {
            var token = _context.AuthToken.FirstOrDefault(x => x.UserId == userId);

            if (token is null)
            {
                token = new AuthToken(bearerToken, userId);
                await _context.AuthToken.AddAsync(token);

            }
            else
            {
                token.UpdateBearer(bearerToken);
                _context.AuthToken.Update(token);
            }

            if (await _context.SaveChangesAsync() < 0)
                return new TokenNotSaved();


            return true;
        }
    }
}
