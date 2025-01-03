﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiarioOficial.Domain.Entities.OfficialStateDiary;

namespace DiarioOficial.Domain.Entities.Person
{
    public class Person : BaseEntity.BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long UserId { get; private set; }
        public ICollection<OfficialDiaries> OfficialDiaries { get; private set; }
        public ICollection<Session.Session> Sessions { get; private set; }

        private Person() { }

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void UpdatePerson(string name, string email)
        {
            Name = name;
            Email = email;
        }

        #region [Foreign Key]
        [ForeignKey(nameof(UserId))]
        public User.User User { get; set; }

        #endregion

    }
}
