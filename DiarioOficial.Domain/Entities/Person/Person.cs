using System.ComponentModel.DataAnnotations;

namespace DiarioOficial.Domain.Entities.Person
{
    public class Person : BaseEntity.BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }

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

    }
}
