using System;

namespace EFInheritanceTypes.Entities
{
    public class Teacher : BasEntity<string>
    {
        public DateTime HiredDate { get; set; }
    }
}