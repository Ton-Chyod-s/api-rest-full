namespace DiarioOficial.Domain.Entities.OfficialStateDiary
{
    public class OfficialStateDiary : BaseEntity.BaseEntity
    {
        public string? Title { get; private set; }

        private OfficialStateDiary() { }

        public OfficialStateDiary(string title)
        {
            Title = title;
        }

    }
}
