using System;

namespace EFInheritanceTypes.Entities
{
    public class Student : BasEntity<int>
    {
        public DateTime EnrollmentDate { get; set; }
    }
}