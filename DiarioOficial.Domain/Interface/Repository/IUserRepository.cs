using DiarioOficial.Domain.Entities.User;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByName(string name, string password);
    }
}
