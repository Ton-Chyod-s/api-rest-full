using System.ComponentModel.DataAnnotations;

namespace DiarioOficial.Domain.Entities.Person
{
    public class Person : BaseEntity.BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        private Person() { }

        public Person(string name)
        {
            Name = name;
        }

        public void UpdatePerson(string name)
        {
            Name = name;
        }

    }
}
