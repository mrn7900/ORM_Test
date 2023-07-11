using Microsoft.EntityFrameworkCore;
using ORM_Test.Models;

namespace ORM_Test.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
