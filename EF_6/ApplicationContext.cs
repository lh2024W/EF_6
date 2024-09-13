using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null;
        public DbSet<Author> Authors { get; set; } = null;
        public DbSet<Genre> Genres { get; set; } = null;

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(a => a.Author);
            modelBuilder.Entity<Book>().HasOne(g => g.Genre);
            base.OnModelCreating(modelBuilder);
        }
    }
}
