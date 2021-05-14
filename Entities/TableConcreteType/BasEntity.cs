using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritanceTypes.Entities
{
    public class BasEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
    }
}