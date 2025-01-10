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
        new AgeGroup { Id = 3, Group = "35-44" },
        new AgeGroup { Id = 4, Group = "45-54" },
        new AgeGroup { Id = 5, Group = "55-64" },
        new AgeGroup { Id = 6, Group = "65-74" }
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
     new Location { Id = 1, LocationValue = "Downtown LA" },
     new Location { Id = 2, LocationValue = "Hollywood" },
     new Location { Id = 3, LocationValue = "Beverly Hills" },
     new Location { Id = 4, LocationValue = "Santa Monica" },
     new Location { Id = 5, LocationValue = "Venice" },
     new Location { Id = 6, LocationValue = "Pasadena" },
     new Location { Id = 7, LocationValue = "Westwood" },
     new Location { Id = 8, LocationValue = "Silver Lake" },
     new Location { Id = 9, LocationValue = "Echo Park" },
     new Location { Id = 10, LocationValue = "Culver City" }
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
    new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Address = "123 Main St, Downtown LA", AgeGroupId = 1, GenderId = 1, RaceId = 1, LocationId = 1 },
    new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Address = "456 Elm St, Hollywood", AgeGroupId = 2, GenderId = 2, RaceId = 2, LocationId = 2 },
    new Customer { Id = 3, Name = "Mark Brown", Email = "mark.brown@example.com", Address = "789 Oak St, Beverly Hills", AgeGroupId = 3, GenderId = 1, RaceId = 3, LocationId = 3 },
    new Customer { Id = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Address = "111 Maple Ave, Santa Monica", AgeGroupId = 4, GenderId = 2, RaceId = 4, LocationId = 4 },
    new Customer { Id = 5, Name = "Michael Wilson", Email = "michael.wilson@example.com", Address = "222 Pine St, Venice", AgeGroupId = 5, GenderId = 3, RaceId = 1, LocationId = 5 },
    new Customer { Id = 6, Name = "Sarah Johnson", Email = "sarah.johnson@example.com", Address = "333 Cedar Rd, Pasadena", AgeGroupId = 6, GenderId = 2, RaceId = 2, LocationId = 6 },
    new Customer { Id = 7, Name = "David Lee", Email = "david.lee@example.com", Address = "444 Birch Ln, Westwood", AgeGroupId = 1, GenderId = 3, RaceId = 3, LocationId = 7 },
    new Customer { Id = 8, Name = "Jessica White", Email = "jessica.white@example.com", Address = "555 Willow Dr, Silver Lake", AgeGroupId = 2, GenderId = 1, RaceId = 4, LocationId = 8 },
    new Customer { Id = 9, Name = "James Miller", Email = "james.miller@example.com", Address = "666 Vine St, Echo Park", AgeGroupId = 3, GenderId = 3, RaceId = 1, LocationId = 9 },
    new Customer { Id = 10, Name = "Laura Moore", Email = "laura.moore@example.com", Address = "777 Redwood St, Culver City", AgeGroupId = 4, GenderId = 2, RaceId = 2, LocationId = 10 },
    new Customer { Id = 11, Name = "Robert Clark", Email = "robert.clark@example.com", Address = "888 Laurel St, Downtown LA", AgeGroupId = 5, GenderId = 1, RaceId = 3, LocationId = 1 },
    new Customer { Id = 12, Name = "Linda Martinez", Email = "linda.martinez@example.com", Address = "999 Cherry Ave, Hollywood", AgeGroupId = 6, GenderId = 2, RaceId = 4, LocationId = 2 },
    new Customer { Id = 13, Name = "Charles Garcia", Email = "charles.garcia@example.com", Address = "123 Cypress Ln, Beverly Hills", AgeGroupId = 1, GenderId = 3, RaceId = 1, LocationId = 3 },
    new Customer { Id = 14, Name = "Sophia Rodriguez", Email = "sophia.rodriguez@example.com", Address = "456 Magnolia Blvd, Santa Monica", AgeGroupId = 2, GenderId = 1, RaceId = 2, LocationId = 4 },
    new Customer { Id = 15, Name = "Daniel Hall", Email = "daniel.hall@example.com", Address = "789 Dogwood St, Venice", AgeGroupId = 3, GenderId = 3, RaceId = 3, LocationId = 5 },
    new Customer { Id = 16, Name = "Olivia Lopez", Email = "olivia.lopez@example.com", Address = "111 Fir St, Pasadena", AgeGroupId = 4, GenderId = 2, RaceId = 4, LocationId = 6 },
    new Customer { Id = 17, Name = "Paul Hernandez", Email = "paul.hernandez@example.com", Address = "222 Ash St, Westwood", AgeGroupId = 5, GenderId = 1, RaceId = 1, LocationId = 7 },
    new Customer { Id = 18, Name = "Anna King", Email = "anna.king@example.com", Address = "333 Palm Ave, Silver Lake", AgeGroupId = 6, GenderId = 2, RaceId = 2, LocationId = 8 },
    new Customer { Id = 19, Name = "Steven Wright", Email = "steven.wright@example.com", Address = "444 Fir Ln, Echo Park", AgeGroupId = 1, GenderId = 3, RaceId = 3, LocationId = 9 },
    new Customer { Id = 20, Name = "Megan Scott", Email = "megan.scott@example.com", Address = "555 Oak Blvd, Culver City", AgeGroupId = 2, GenderId = 1, RaceId = 4, LocationId = 10 }
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