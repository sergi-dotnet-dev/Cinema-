using Microsoft.EntityFrameworkCore;
using RegistrationService.Code.Models;

namespace RegistrationService.DAL;

public class RegistrationBoundedContext : DbContext
{
    private readonly String _connString;
    public DbSet<User> Users { get; set; }

    public RegistrationBoundedContext(String connString)
    {
        _connString = connString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_connString);
    }
}
