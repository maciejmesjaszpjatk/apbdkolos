using KolokwiumAPBD.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<WashingProgram> Programs { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PurchaseHistory>()
            .HasKey(ph => new { ph.AvailableProgramId, ph.CustomerId });

        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Maciej",LastName = "Mesjasz",PhoneNumber = "+48794287703"}
        );
        modelBuilder.Entity<WashingProgram>().HasData(
            new WashingProgram { ProgramId = 1, Name = "Quickie", DurationMinutes = 69, TemperatureCelcius = 30 },
            new WashingProgram { ProgramId = 2, Name = "CottonDestroyer", DurationMinutes = 143, TemperatureCelcius = 90 },
            new WashingProgram { ProgramId = 3, Name = "Synthetic", DurationMinutes = 90, TemperatureCelcius = 5 }
        );

        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine { WashingMachineId = 1, SerialNumber = "APBD1111/S123/15", MaxWeight = 32.12m },
            new WashingMachine { WashingMachineId = 2, SerialNumber = "APBD1112/S123/24", MaxWeight = 55.23m }
        );

        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram { AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 33.4m },
            new AvailableProgram { AvailableProgramId = 2, WashingMachineId = 2, ProgramId = 2, Price = 48.7m }
        );

        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory { CustomerId = 1, AvailableProgramId = 1, PurchaseDate = DateTime.Parse("2025-06-08T10:00:00"), Rating = 5 },
            new PurchaseHistory { CustomerId = 1, AvailableProgramId = 2, PurchaseDate = DateTime.Parse("2025-06-08T11:00:00"), Rating = null }
        );
    }
}