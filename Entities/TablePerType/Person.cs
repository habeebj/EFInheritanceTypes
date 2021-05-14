using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritanceTypes.Entities
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}