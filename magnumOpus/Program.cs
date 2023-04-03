
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

namespace MySQLExample
{
    class Program
    {
        static void Main(string[] args)
        {
         
            try
            {
                connection.Open();

                string query = "INSERT INTO gg (mame) VALUES (@randomWord)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@value1", "Value 1");
     //           command.Parameters.AddWithValue("@value2", "Value 2");
     //           command.Parameters.AddWithValue("@value3", "Value 3");

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine("Rows affected: " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Console.ReadKey();
        }
    }
}

 
namespace MySQLApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=usersdb5;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}