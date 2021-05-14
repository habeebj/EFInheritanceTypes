using EFInheritanceTypes.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFInheritanceTypes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        // Table-per-Hierarchy (TPH)
        public DbSet<BillingDetail> BankDetails { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }


        // Table-per-Type (TPT)
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        // Table-per-Conrete-type
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

}