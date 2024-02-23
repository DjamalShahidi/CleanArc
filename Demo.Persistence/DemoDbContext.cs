using Demo.Domain;
using Demo.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;

                if (entry.State==EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Book> Books { get; set; }
    }
}
