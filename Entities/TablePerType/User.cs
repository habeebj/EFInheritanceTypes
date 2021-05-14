using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritanceTypes.Entities
{
    [Table("User")]
    public class User : Person
    {
        public string UserName { get; set; }
    }
}