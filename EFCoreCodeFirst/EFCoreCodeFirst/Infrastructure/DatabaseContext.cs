using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    
}