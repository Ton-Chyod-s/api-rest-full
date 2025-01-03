using System.ComponentModel.DataAnnotations.Schema;

namespace DiarioOficial.Domain.Entities.Session
{
    public class Session : BaseEntity.BaseEntity
    {
        public long PersonID { get; set; }
        public string Year { get; set; }
        public ICollection<OfficialStateDiary.OfficialDiaries> OfficialStateDiaries { get; set; }

        private Session() { }

        public Session(long personID, string year)
        {
            PersonID = personID;
            Year = year;
        }

        public void AddOfficialStateDiary(OfficialStateDiary.OfficialDiaries officialStateDiary)
        {
            OfficialStateDiaries.Add(officialStateDiary);
        }

        #region [Foreign Key]
        [ForeignKey(nameof(PersonID))]
        public Person.Person Person { get; set; }
        #endregion
    }
}
