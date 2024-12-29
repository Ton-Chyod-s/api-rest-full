namespace DiarioOficial.Domain.Entities.Session
{
    public class Session : BaseEntity.BaseEntity
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public ICollection<OfficialStateDiary.OfficialStateDiary> OfficialStateDiaries { get; private set; } = [];

        private Session() { }
    }
}
