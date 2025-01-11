using DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.CrossCutting.Errors;
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

        public async Task<OneOf<bool, BaseError>> AddOrUpdateUser(User user)
        {
            var findUser = await _context.User.FirstOrDefaultAsync(x => x.UserName == user.UserName);

            if (findUser is null)
            {
                var newUser = new User
                (
                    user.UserName,
                    user.PassWordHash,
                    user.IsActive,
                    user.Roles
                );
                await _context.User.AddAsync(newUser);
            }
            else
            {
                findUser.UpdateUser
                (
                    user.UserName,
                    user.IsActive,
                    user.Roles
                );
                _context.User.Update(findUser);
            }

            if (await _context.SaveChangesAsync() < 0)
                return new UserNotSaved();

            return true;
        }

        public async Task<OneOf<bool, BaseError>> AddOrUpdateToken(string bearerToken, long userId)
        {
            var token = _context.AuthToken.FirstOrDefault(x => x.UserId == userId);

            if (token is null)
            {
                var newToken = new AuthToken(bearerToken, userId);
                await _context.AuthToken.AddAsync(newToken);

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
