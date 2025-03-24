using Microsoft.EntityFrameworkCore;
using React.DB.Configurations;
using React.DB.Entities;

namespace React.DB;

public class AppDbCtx(DbContextOptions<AppDbCtx> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StatusesConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}