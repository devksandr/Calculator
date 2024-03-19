using Calculator.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Backend.Data
{
    public class CalculatorDataContext : DbContext
    {
        public CalculatorDataContext(DbContextOptions<CalculatorDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultOperations = new Operation[]
            {
                new Operation { Id = Guid.NewGuid(), Name = "Sum" }
            };

            modelBuilder.Entity<Operation>().HasData(defaultOperations);

            modelBuilder.UseSerialColumns();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
