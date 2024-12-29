using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiarioOficial.Domain.Entities.OfficialStateDiary
{
    public class OfficialStateDiary : BaseEntity.BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Number { get; private set; }
        public string Day { get; private set; }
        public string File { get; private set; }
        public string Description { get; private set; }
        public long SessionId { get; private set; }

        private OfficialStateDiary() { }
      
        public OfficialStateDiary(string number, string day, string file, string description, long sessionId)
        {
            Number = number;
            Day = day;
            File = file;
            Description = description;
            SessionId = sessionId;
        }

        #region [Foreign Key]
        [ForeignKey(nameof(SessionId))]
        public Session.Session Session { get; private set; }
        #endregion
    }
}
