using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritanceTypes.Entities
{
    [Table("Client")]
    public class Client : Person
    {
        public string Email { get; set; }
    }
}