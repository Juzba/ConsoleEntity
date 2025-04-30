using Microsoft.EntityFrameworkCore;

namespace ConsoleEntity.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<IssDbPosition> IssDbPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=LearningDB; Trusted_Connection=True;");
        }
    }
}
