using DatabaseInteraction.Models.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace DatabaseInteraction.DatabaseConfiguration;

public class DatabaseContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }
}