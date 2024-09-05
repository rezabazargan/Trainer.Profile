using Microsoft.EntityFrameworkCore;
using Trainer.Profile.Adaptors.Ef.Entities;

namespace Trainer.Profile.Adaptors.Ef;

internal class TrainerProfileDbContext(DbContextOptions<TrainerProfileDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("profile");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TrainerEntity> Trainers { get; set; }
}