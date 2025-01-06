using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TequioDemoTrack.Models;
using Microsoft.AspNetCore.Identity;

namespace TequioDemoTrack.Data;
public class TequioDemoTrackDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    public DbSet<AgeGroup> AgeGroups { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Race> Races { get; set; }


    public TequioDemoTrackDbContext(DbContextOptions<TequioDemoTrackDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<AgeGroup>().HasData(
        new AgeGroup { Id = 1, Group = "18-24" },
        new AgeGroup { Id = 2, Group = "25-34" },
        new AgeGroup { Id = 3, Group = "35-44" }
    );

        // Seed data for Gender
        modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, GenderValue = "Male" },
            new Gender { Id = 2, GenderValue = "Female" },
            new Gender { Id = 3, GenderValue = "Non-binary" }
        );

        // Seed data for Race
        modelBuilder.Entity<Race>().HasData(
            new Race { Id = 1, RaceValue = "Asian" },
            new Race { Id = 2, RaceValue = "Black" },
            new Race { Id = 3, RaceValue = "White" },
            new Race { Id = 4, RaceValue = "Hispanic" }
        );

        // Seed data for Location
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, LocationValue = "New York" },
            new Location { Id = 2, LocationValue = "Los Angeles" },
            new Location { Id = 3, LocationValue = "Chicago" }
        );

        // Seed data for Product
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Tequila Blanco", Price = 25.00m },
            new Product { Id = 2, Name = "Tequila Reposado", Price = 30.00m },
            new Product { Id = 3, Name = "Tequila Añejo", Price = 40.00m }
  );


        // Seed data for Employee
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Juan Perez", Email = "juan.perez@example.com", Address = "123 Agave St, Mexico City", IsActive = true },
            new Employee { Id = 2, Name = "Maria Lopez", Email = "maria.lopez@example.com", Address = "456 Tequila Rd, Guadalajara", IsActive = true }
        );

        // Seed data for Customer
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Address = "789 Lime Ave, Miami", AgeGroupId = 2, GenderId = 1, RaceId = 3, LocationId = 3 },
            new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Address = "321 Salt Blvd, Los Angeles", AgeGroupId = 1, GenderId = 2, RaceId = 2, LocationId = 2 }
        );

        // Seed data for Purchases
        modelBuilder.Entity<Purchase>().HasData(
            new Purchase { Id = 1, CustomerId = 1, EmployeeId = 1, PurchaseDate = new DateTime(2024, 1, 1) },
            new Purchase { Id = 2, CustomerId = 2, EmployeeId = 2, PurchaseDate = new DateTime(2024, 2, 15) }
        );

        modelBuilder.Entity<PurchaseProduct>().HasData(
            new PurchaseProduct { Id = 1, PurchaseId = 1, ProductId = 2, Quantity = 1 },
            new PurchaseProduct { Id = 2, PurchaseId = 2, ProductId = 3, Quantity = 1 }
        );


    }
}