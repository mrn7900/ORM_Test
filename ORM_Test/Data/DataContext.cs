using Microsoft.EntityFrameworkCore;
using ORM_Test.Models;

namespace ORM_Test.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
        {

        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=test1;Uid=root;Pwd=12345678;");
        }
    }
}
