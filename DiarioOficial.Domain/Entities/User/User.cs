using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.Domain.Entities.User
{
    public class User : BaseEntity.BaseEntity
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
        public UserEnum Roles { get; private set; }

        private User() { }

        public User(string username, string passwordHash, string email, bool isActive, UserEnum roles)
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            IsActive = isActive;
            Roles = roles;
        }

        public void Update(string username, string email, bool isActive, UserEnum roles)
        {
            Username = username;
            Email = email;
            IsActive = isActive;
            Roles = roles;
        }
    }
}
