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
        new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Address = "321 Salt Blvd, Los Angeles", AgeGroupId = 1, GenderId = 2, RaceId = 2, LocationId = 2 },
        new Customer { Id = 3, Name = "Mark Brown", Email = "mark.brown@example.com", Address = "456 Oak St, New York", AgeGroupId = 3, GenderId = 1, RaceId = 1, LocationId = 1 },
        new Customer { Id = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Address = "123 Pine Rd, Chicago", AgeGroupId = 2, GenderId = 2, RaceId = 4, LocationId = 4 },
        new Customer { Id = 5, Name = "Michael Wilson", Email = "michael.wilson@example.com", Address = "876 Birch Ln, Houston", AgeGroupId = 4, GenderId = 1, RaceId = 2, LocationId = 5 },
        new Customer { Id = 6, Name = "Sarah Johnson", Email = "sarah.johnson@example.com", Address = "789 Maple Ave, Seattle", AgeGroupId = 1, GenderId = 2, RaceId = 5, LocationId = 6 },
        new Customer { Id = 7, Name = "David Lee", Email = "david.lee@example.com", Address = "654 Cedar St, San Francisco", AgeGroupId = 3, GenderId = 1, RaceId = 3, LocationId = 7 },
        new Customer { Id = 8, Name = "Jessica White", Email = "jessica.white@example.com", Address = "951 Elm St, Austin", AgeGroupId = 2, GenderId = 2, RaceId = 1, LocationId = 8 },
        new Customer { Id = 9, Name = "James Miller", Email = "james.miller@example.com", Address = "321 Willow St, Denver", AgeGroupId = 4, GenderId = 1, RaceId = 4, LocationId = 9 },
        new Customer { Id = 10, Name = "Laura Moore", Email = "laura.moore@example.com", Address = "222 Spruce Ln, Portland", AgeGroupId = 3, GenderId = 2, RaceId = 5, LocationId = 10 },
        new Customer { Id = 11, Name = "Robert Clark", Email = "robert.clark@example.com", Address = "987 Redwood St, Boston", AgeGroupId = 1, GenderId = 1, RaceId = 2, LocationId = 11 },
        new Customer { Id = 12, Name = "Linda Martinez", Email = "linda.martinez@example.com", Address = "123 Cherry Ave, Phoenix", AgeGroupId = 2, GenderId = 2, RaceId = 3, LocationId = 12 },
        new Customer { Id = 13, Name = "Charles Garcia", Email = "charles.garcia@example.com", Address = "321 Palm Blvd, Orlando", AgeGroupId = 4, GenderId = 1, RaceId = 1, LocationId = 13 },
        new Customer { Id = 14, Name = "Sophia Rodriguez", Email = "sophia.rodriguez@example.com", Address = "555 Vine Rd, Dallas", AgeGroupId = 3, GenderId = 2, RaceId = 4, LocationId = 14 },
        new Customer { Id = 15, Name = "Daniel Hall", Email = "daniel.hall@example.com", Address = "876 Magnolia Ln, Atlanta", AgeGroupId = 1, GenderId = 1, RaceId = 5, LocationId = 15 },
        new Customer { Id = 16, Name = "Olivia Lopez", Email = "olivia.lopez@example.com", Address = "654 Ash St, San Diego", AgeGroupId = 2, GenderId = 2, RaceId = 2, LocationId = 16 },
        new Customer { Id = 17, Name = "Paul Hernandez", Email = "paul.hernandez@example.com", Address = "111 Fir St, Sacramento", AgeGroupId = 4, GenderId = 1, RaceId = 3, LocationId = 17 },
        new Customer { Id = 18, Name = "Anna King", Email = "anna.king@example.com", Address = "543 Cypress Ln, Nashville", AgeGroupId = 3, GenderId = 2, RaceId = 4, LocationId = 18 },
        new Customer { Id = 19, Name = "Steven Wright", Email = "steven.wright@example.com", Address = "321 Laurel Rd, Charlotte", AgeGroupId = 1, GenderId = 1, RaceId = 1, LocationId = 19 },
        new Customer { Id = 20, Name = "Megan Scott", Email = "megan.scott@example.com", Address = "987 Dogwood St, Detroit", AgeGroupId = 2, GenderId = 2, RaceId = 5, LocationId = 20 }
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