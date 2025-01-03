using System.ComponentModel.DataAnnotations.Schema;

namespace DiarioOficial.Domain.Entities.Session
{
    public class Session : BaseEntity.BaseEntity
    {
        public long NameID { get; set; }
        public string Year { get; set; }
        public ICollection<OfficialStateDiary.OfficialDiaries> OfficialStateDiaries { get; set; }

        private Session() { }

        public Session(long nameID, string year)
        {
            NameID = nameID;
            Year = year;
        }

        public void AddOfficialStateDiary(OfficialStateDiary.OfficialDiaries officialStateDiary)
        {
            OfficialStateDiaries.Add(officialStateDiary);
        }

        #region [Foreign Key]
        [ForeignKey(nameof(NameID))]
        public Person.Person Person { get; set; }
        #endregion
    }
}
