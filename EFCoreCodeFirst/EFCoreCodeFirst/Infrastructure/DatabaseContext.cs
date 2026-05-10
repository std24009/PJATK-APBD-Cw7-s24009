using EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PCComponents> PcComponents { get; set; }
}