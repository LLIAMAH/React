using Microsoft.EntityFrameworkCore;
using React.DB.Entities;

namespace React.DB;

public class AppDbCtx(DbContextOptions<AppDbCtx> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}