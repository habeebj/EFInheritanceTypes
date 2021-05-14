using System;
using EFInheritanceTypes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFInheritanceTypes
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=app.db")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                await context.BankDetails.AddAsync(new BillingDetail { Number = "0023123232", Owner = "John" });
                await context.BankDetails.AddAsync(new BankAccount { Number = "3290390021", Owner = "Doe", BankName = "MidBank", Swift = "MIDBANXXX" });
                await context.BankDetails.AddAsync(new CreditCard { Number = "1200328798", Owner = "Jessica", ExpiryMonth = "05", ExpiryYear = "21" });

                await context.People.AddAsync(new Person { Name = "Janet" });
                await context.People.AddAsync(new User { Name = "Ayo", UserName = "ay21" });
                await context.People.AddAsync(new Client { Name = "Segun", Email = "segun@example.com" });

                await context.Set<Student>().AddAsync(new Student { Name = "Smith", EnrollmentDate = DateTime.Parse("2020/12/12") });
                await context.Set<Teacher>().AddAsync(new Teacher { Name = "Bob", HiredDate = DateTime.Parse("2001/02/13") });

                await context.SaveChangesAsync();

                var bankDetails = await context.BankDetails.ToListAsync();
                // bankDetails.ForEach(b => Console.WriteLine($"{b.Number}, {b.Owner}"));
            }
        }
    }
}
