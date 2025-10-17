using k8s.KubeConfigModels;
using Microsoft.EntityFrameworkCore;
using RFFC.Entities;

namespace RFFC.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    public DbSet<RFC> RFCs { get; set; }
    public DbSet<MessageRequest> Messages { get; set; }
    private DbSet<Entities.User> users;

    public DbSet<Entities.User> GetUsers()
    {
        return users;
    }

    public void SetUsers(DbSet<Entities.User> value)
    {
        users = value;
    }

    public override int SaveChanges()
    {
        ApplyEntityTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyEntityTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyEntityTimestamps()
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
    }
}
