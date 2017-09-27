using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreDockerMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseMySql("server=efcoredockermysql-mysql;userid=root;pwd=p4ssw0r#;port=3306;database=efcoredockermysql;sslmode=none;");
            AddOrUpdateDavid(builder.Options);
            ShowAllPeople(builder.Options);
        }

        private static void AddOrUpdateDavid(DbContextOptions<ApplicationDbContext> options)
        {
            using (var context = new ApplicationDbContext(options))
            {
                var david = context.People.FirstOrDefaultAsync(x => x.Name == "David").Result;

                if (david != null)
                {
                    david.Surname += "*";
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
                    Console.WriteLine($"{person.Name} {person.Surname}");
                }
            }
        }
    }
}
