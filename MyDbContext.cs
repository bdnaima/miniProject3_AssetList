using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class MyDbContext : DbContext
{
    public DbSet<Asset> Assets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>()
            .HasDiscriminator<string>("AssetType")
            .HasValue<Computer>("Computer")
            .HasValue<MobilePhone>("MobilePhone");

        modelBuilder.Entity<Computer>().HasData(
                new Computer
                {
                    AssetId = 1001,
                    Brand = "Dell",
                    Model = "Latitude 5440",
                    PurchaseDate = new DateTime(2024, 1, 15),
                    PriceUSD = 1200,
                    Office = "Sweden",
                    Currency = "SEK",
                    SerialNumber = "DELL001",
                    AssignedEmployee = "Anna",
                    WarrantyExpirationDate = new DateTime(2027, 1, 15)
                },
                new Computer
                {
                    AssetId = 1002,
                    Brand = "Apple",
                    Model = "MacBook Pro M3",
                    PurchaseDate = new DateTime(2023, 6, 10),
                    PriceUSD = 2500,
                    Office = "USA",
                    Currency = "USD",
                    SerialNumber = "APPLE001",
                    AssignedEmployee = "John",
                    WarrantyExpirationDate = new DateTime(2026, 6, 10)
                }
                );

        modelBuilder.Entity<MobilePhone>().HasData(
            new MobilePhone
            {
                AssetId = 1003,
                Brand = "Samsung",
                Model = "Galaxy S24",
                PurchaseDate = new DateTime(2025, 2, 1),
                PriceUSD = 900,
                Office = "Germany",
                Currency = "EUR",
                SerialNumber = "SAM001",
                AssignedEmployee = "Maria",
                WarrantyExpirationDate = new DateTime(2027, 2, 1)
            }
        );
    }
}