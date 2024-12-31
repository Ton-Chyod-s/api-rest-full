namespace DiarioOficial.Domain.Entities.Token
{
    public class AuthToken : BaseEntity.BaseEntity
    {
        public long Bearer { get; private set; }

        private AuthToken() { } 

        public AuthToken(long bearer)
        {
            Bearer = bearer;
        }

        public void UpdateBearer(long bearer)
        {
            Bearer = bearer;
        }

    }
}
