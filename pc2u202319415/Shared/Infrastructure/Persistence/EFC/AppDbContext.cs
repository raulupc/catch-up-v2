using Microsoft.EntityFrameworkCore;
using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pc2u202319415.Shared.Infrastructure.Persistence.EFC;

/// <summary>
/// DbContext para el esquema travelers.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplySnakeCaseConfiguration();
        modelBuilder.Entity<Plan>(builder =>
        {
            builder.ToTable("plans", "travelers");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Name).HasMaxLength(120).IsRequired();
            builder.Property(p => p.MaxUsers).IsRequired();
            builder.Property(p => p.IsDefault).IsRequired();
            builder.Property(p => p.MonetizationStrategyId).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired();
        });
    }
}