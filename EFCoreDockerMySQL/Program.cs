using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EFCoreDockerMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            AddOrUpdateDavid(builder.Options);
            ShowAllPeople(builder.Options);
        }

        public static IConfigurationRoot Configuration
        {
            get
            {
                var environmentName = Environment.GetEnvironmentVariable("DOTNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true);
                return builder.Build();
            }
        }

        private static void AddOrUpdateDavid(DbContextOptions<ApplicationDbContext> options)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var david = context.People.FirstOrDefaultAsync(x => x.Name == "David").Result;

                if (david != null)
                {
                    david.Surname += "*";
                    if (david.Email == null)
                    {
                        david.Email = "david.gilmour@gmail.com";
                    }
                }
                else
                {
                    david = new Person
                    {
                        Name = "David",
                        Surname = "Gilmour"
                    };
                    context.People.Add(david);
                }
                context.SaveChanges();
            }
        }

        private static void ShowAllPeople(DbContextOptions<ApplicationDbContext> options)
        {
            using (var context = new ApplicationDbContext(options))
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine($"{person.Name} {person.Surname}<{person.Email}>");
                }
            }
        }
    }
}
