using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class MyDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Computer> Computers { get; set; }

    public DbSet<MobilePhone> MobilePhones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

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
    }
}