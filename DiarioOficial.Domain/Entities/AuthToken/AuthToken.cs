using System.ComponentModel.DataAnnotations.Schema;
using DiarioOficial.CrossCutting.DTOs.Token;

namespace DiarioOficial.Domain.Entities.Token
{
    public class AuthToken : BaseEntity.BaseEntity
    {
        public string Bearer { get; private set; }
        public long UserId { get; private set; }

        private AuthToken() { } 

        public AuthToken(string bearer)
        {
            Bearer = bearer;
        }

        public void UpdateBearer(string bearer)
        {
            Bearer = bearer;
        }

        #region [Foreign Key]
        [ForeignKey(nameof(UserId))]
        public User.User User { get; set; }
        #endregion
    }
}
