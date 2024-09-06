using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace EF_6
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

        class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }

    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }

    public class DatabaseBook
    {
       public void EnsurePopulate()
        {
            using (ApplicationContext db = new ApplicationContext()
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
            }
        }
       

}

    public class Program
    {
        static void Main()
        {
            

        }
    }


