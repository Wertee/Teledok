using Microsoft.EntityFrameworkCore;
using Teledok.Models;

namespace Teledok.EF;

public class TeledokDbContext:DbContext
{
    public TeledokDbContext(DbContextOptions<TeledokDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Founder> Founders { get; set; }
}