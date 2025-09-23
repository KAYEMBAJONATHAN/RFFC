using Microsoft.EntityFrameworkCore;
using RFFC.Entities;

namespace RFFC.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) 
    { 

    }

    public DbSet<RFC> RFCs { get; set; }
    public DbSet<MessageRequest> Messages { get; set; }
    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            entity.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                entity.CreatedAt = DateTime.UtcNow;

            if (entity.RFCId == Guid.Empty)
                entity.RFCId = Guid.NewGuid();

        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            entity.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                entity.CreatedAt = DateTime.UtcNow;

            if (entity.RFCId == Guid.Empty)
                entity.RFCId = Guid.NewGuid();

        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
