using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Data
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public PeopleContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(b => b.LastName)
                .IsRequired(false);
        }
    }
}
