using CarManagementApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApi.Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Engine>? Engines { get; set; }
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Engine>().HasData(
            new Engine()
            {
                Id = 1,
                HorsePower = 300,
                CylinderCount = 4,
                FuelType = "Benzin"
            },
            new Engine()
            {
                Id = 2,
                HorsePower = 400,
                CylinderCount = 8,
                FuelType = "LPG"
            }
        );
        modelBuilder.Entity<Car>().HasData(
            new Car()
            {
                Id = 1,
                Brand = "BMW",
                Model = "xl01",
                Year = 2020,
                Price = 900000,
                EngineId = 2
            },
            new Car()
            {
                Id = 2,
                Brand = "Mercedes",
                Model = "c6",
                Year = 2019,
                Price = 150000,
                EngineId = 1
            }
        );
    }
}