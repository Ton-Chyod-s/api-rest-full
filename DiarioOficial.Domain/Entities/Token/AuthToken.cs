namespace DiarioOficial.Domain.Entities.Token
{
    public class AuthToken : BaseEntity.BaseEntity
    {
        public string Bearer { get; private set; }

        private AuthToken() { } 

        public AuthToken(string bearer)
        {
            Bearer = bearer;
        }

        public void UpdateBearer(string bearer)
        {
            Bearer = bearer;
        }

    }
}
