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

        modelBuilder.Entity<IdentityUser>().HasData(
        new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },
        new IdentityUser
        {
            Id = "d7f5e876-91fe-4e0b-a2c9-e6a07500f50e",
            UserName = "SmithJordan",
            Email = "jordan@gmail.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },
        new IdentityUser
        {
            Id = "f7b45b7d-3c74-4dfd-a8f9-20fe7b8cb062",
            UserName = "JohnsonTaylor",
            Email = "taylor@gmail.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        }

        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(
        new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        },
        new UserProfile
        {
            Id = 2,
            IdentityUserId = "d7f5e876-91fe-4e0b-a2c9-e6a07500f50e",
            FirstName = "Jordan",
            LastName = "Smith",
            Address = "202 Oak Avenue",
        },
        new UserProfile
        {
            Id = 3,
            IdentityUserId = "f7b45b7d-3c74-4dfd-a8f9-20fe7b8cb062",
            FirstName = "Taylor",
            LastName = "Johnson",
            Address = "303 Pine Street",
        }
    );


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
            new Product { Id = 1, Name = "Sparkling Blanco", Pack = 8, Image = "/Blanco.png", Ingredients = "El Mexicano® Tequila Blanco (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", Price = 39.98m },
            new Product { Id = 2, Name = "Sparkling Blanco", Pack = 24, Image = "/Blanco.png", Ingredients = "El Mexicano® Tequila Blanco (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", Price = 119.94m },
            new Product { Id = 3, Name = "Sparkling Repasado", Pack = 8, Image = "/Repasado.png", Ingredients = "El Mexicano® Tequila Repasado (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", Price = 39.98m },
            new Product { Id = 4, Name = "Sparkling Repasado", Pack = 24, Image = "/Repasado.png", Ingredients = "El Mexicano® Tequila Repasado (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", Price = 119.94m }
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
            new Purchase { Id = 1, CustomerId = 1, UserProfileId = 3, PurchaseDate = new DateTime(2023, 1, 10) },
            new Purchase { Id = 2, CustomerId = 3, UserProfileId = 2, PurchaseDate = new DateTime(2023, 2, 15) },
            new Purchase { Id = 3, CustomerId = 5, UserProfileId = 3, PurchaseDate = new DateTime(2023, 3, 20) },
            new Purchase { Id = 4, CustomerId = 7, UserProfileId = 2, PurchaseDate = new DateTime(2023, 4, 25) },
            new Purchase { Id = 5, CustomerId = 9, UserProfileId = 3, PurchaseDate = new DateTime(2023, 5, 5) },
            new Purchase { Id = 6, CustomerId = 2, UserProfileId = 2, PurchaseDate = new DateTime(2023, 6, 18) },
            new Purchase { Id = 7, CustomerId = 4, UserProfileId = 3, PurchaseDate = new DateTime(2023, 7, 12) },
            new Purchase { Id = 8, CustomerId = 6, UserProfileId = 2, PurchaseDate = new DateTime(2023, 8, 3) },
            new Purchase { Id = 9, CustomerId = 8, UserProfileId = 3, PurchaseDate = new DateTime(2023, 9, 22) },
            new Purchase { Id = 10, CustomerId = 10, UserProfileId = 2, PurchaseDate = new DateTime(2023, 10, 30) },
            new Purchase { Id = 11, CustomerId = 1, UserProfileId = 3, PurchaseDate = new DateTime(2024, 1, 5) },
            new Purchase { Id = 12, CustomerId = 3, UserProfileId = 2, PurchaseDate = new DateTime(2024, 2, 14) },
            new Purchase { Id = 13, CustomerId = 5, UserProfileId = 3, PurchaseDate = new DateTime(2024, 3, 9) },
            new Purchase { Id = 14, CustomerId = 7, UserProfileId = 2, PurchaseDate = new DateTime(2024, 4, 23) },
            new Purchase { Id = 15, CustomerId = 9, UserProfileId = 3, PurchaseDate = new DateTime(2024, 5, 17) },
            new Purchase { Id = 16, CustomerId = 2, UserProfileId = 2, PurchaseDate = new DateTime(2024, 6, 11) },
            new Purchase { Id = 17, CustomerId = 4, UserProfileId = 3, PurchaseDate = new DateTime(2024, 7, 15) },
            new Purchase { Id = 18, CustomerId = 6, UserProfileId = 2, PurchaseDate = new DateTime(2024, 8, 8) },
            new Purchase { Id = 19, CustomerId = 8, UserProfileId = 3, PurchaseDate = new DateTime(2024, 9, 27) },
            new Purchase { Id = 20, CustomerId = 10, UserProfileId = 2, PurchaseDate = new DateTime(2024, 10, 4) },
            new Purchase { Id = 21, CustomerId = 1, UserProfileId = 3, PurchaseDate = new DateTime(2025, 1, 12) },
            new Purchase { Id = 22, CustomerId = 3, UserProfileId = 2, PurchaseDate = new DateTime(2025, 2, 22) },
            new Purchase { Id = 23, CustomerId = 5, UserProfileId = 3, PurchaseDate = new DateTime(2025, 3, 8) },
            new Purchase { Id = 24, CustomerId = 7, UserProfileId = 2, PurchaseDate = new DateTime(2025, 4, 15) },
            new Purchase { Id = 25, CustomerId = 9, UserProfileId = 3, PurchaseDate = new DateTime(2025, 5, 30) },
            new Purchase { Id = 26, CustomerId = 2, UserProfileId = 2, PurchaseDate = new DateTime(2025, 6, 13) },
            new Purchase { Id = 27, CustomerId = 4, UserProfileId = 3, PurchaseDate = new DateTime(2025, 7, 24) },
            new Purchase { Id = 28, CustomerId = 6, UserProfileId = 2, PurchaseDate = new DateTime(2025, 8, 19) },
            new Purchase { Id = 29, CustomerId = 8, UserProfileId = 3, PurchaseDate = new DateTime(2025, 9, 25) },
            new Purchase { Id = 30, CustomerId = 10, UserProfileId = 2, PurchaseDate = new DateTime(2025, 10, 18) }
);

        modelBuilder.Entity<PurchaseProduct>().HasData(
            new PurchaseProduct { Id = 1, PurchaseId = 1, ProductId = 1, Quantity = 2 },
    new PurchaseProduct { Id = 2, PurchaseId = 1, ProductId = 3, Quantity = 1 },
    new PurchaseProduct { Id = 3, PurchaseId = 2, ProductId = 2, Quantity = 3 },
    new PurchaseProduct { Id = 4, PurchaseId = 2, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 5, PurchaseId = 3, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 6, PurchaseId = 3, ProductId = 2, Quantity = 1 },
    new PurchaseProduct { Id = 7, PurchaseId = 4, ProductId = 1, Quantity = 3 },
    new PurchaseProduct { Id = 8, PurchaseId = 4, ProductId = 2, Quantity = 2 },
    new PurchaseProduct { Id = 9, PurchaseId = 5, ProductId = 3, Quantity = 1 },
    new PurchaseProduct { Id = 10, PurchaseId = 5, ProductId = 1, Quantity = 4 },
    new PurchaseProduct { Id = 11, PurchaseId = 6, ProductId = 2, Quantity = 2 },
    new PurchaseProduct { Id = 12, PurchaseId = 6, ProductId = 3, Quantity = 3 },
    new PurchaseProduct { Id = 13, PurchaseId = 7, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 14, PurchaseId = 7, ProductId = 2, Quantity = 3 },
    new PurchaseProduct { Id = 15, PurchaseId = 8, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 16, PurchaseId = 8, ProductId = 1, Quantity = 5 },
    new PurchaseProduct { Id = 17, PurchaseId = 9, ProductId = 2, Quantity = 4 },
    new PurchaseProduct { Id = 18, PurchaseId = 9, ProductId = 3, Quantity = 1 },
    new PurchaseProduct { Id = 19, PurchaseId = 10, ProductId = 1, Quantity = 2 },
    new PurchaseProduct { Id = 20, PurchaseId = 10, ProductId = 2, Quantity = 3 },
    new PurchaseProduct { Id = 21, PurchaseId = 11, ProductId = 3, Quantity = 1 },
    new PurchaseProduct { Id = 22, PurchaseId = 11, ProductId = 2, Quantity = 2 },
    new PurchaseProduct { Id = 23, PurchaseId = 12, ProductId = 1, Quantity = 3 },
    new PurchaseProduct { Id = 24, PurchaseId = 12, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 25, PurchaseId = 13, ProductId = 2, Quantity = 4 },
    new PurchaseProduct { Id = 26, PurchaseId = 13, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 27, PurchaseId = 14, ProductId = 3, Quantity = 3 },
    new PurchaseProduct { Id = 28, PurchaseId = 14, ProductId = 2, Quantity = 2 },
    new PurchaseProduct { Id = 29, PurchaseId = 15, ProductId = 1, Quantity = 2 },
    new PurchaseProduct { Id = 30, PurchaseId = 15, ProductId = 3, Quantity = 1 },
    new PurchaseProduct { Id = 31, PurchaseId = 16, ProductId = 2, Quantity = 5 },
    new PurchaseProduct { Id = 32, PurchaseId = 16, ProductId = 1, Quantity = 3 },
    new PurchaseProduct { Id = 33, PurchaseId = 17, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 34, PurchaseId = 17, ProductId = 2, Quantity = 4 },
    new PurchaseProduct { Id = 35, PurchaseId = 18, ProductId = 1, Quantity = 3 },
    new PurchaseProduct { Id = 36, PurchaseId = 18, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 37, PurchaseId = 19, ProductId = 2, Quantity = 4 },
    new PurchaseProduct { Id = 38, PurchaseId = 19, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 39, PurchaseId = 20, ProductId = 3, Quantity = 5 },
    new PurchaseProduct { Id = 40, PurchaseId = 20, ProductId = 2, Quantity = 3 },
    new PurchaseProduct { Id = 41, PurchaseId = 21, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 42, PurchaseId = 21, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 43, PurchaseId = 22, ProductId = 2, Quantity = 5 },
    new PurchaseProduct { Id = 44, PurchaseId = 22, ProductId = 1, Quantity = 2 },
    new PurchaseProduct { Id = 45, PurchaseId = 23, ProductId = 3, Quantity = 3 },
    new PurchaseProduct { Id = 46, PurchaseId = 23, ProductId = 2, Quantity = 1 },
    new PurchaseProduct { Id = 47, PurchaseId = 24, ProductId = 1, Quantity = 4 },
    new PurchaseProduct { Id = 48, PurchaseId = 24, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 49, PurchaseId = 25, ProductId = 2, Quantity = 3 },
    new PurchaseProduct { Id = 50, PurchaseId = 25, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 51, PurchaseId = 26, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 52, PurchaseId = 26, ProductId = 2, Quantity = 4 },
    new PurchaseProduct { Id = 53, PurchaseId = 27, ProductId = 1, Quantity = 3 },
    new PurchaseProduct { Id = 54, PurchaseId = 27, ProductId = 3, Quantity = 2 },
    new PurchaseProduct { Id = 55, PurchaseId = 28, ProductId = 2, Quantity = 5 },
    new PurchaseProduct { Id = 56, PurchaseId = 28, ProductId = 1, Quantity = 4 },
    new PurchaseProduct { Id = 57, PurchaseId = 29, ProductId = 3, Quantity = 3 },
    new PurchaseProduct { Id = 58, PurchaseId = 29, ProductId = 2, Quantity = 2 },
    new PurchaseProduct { Id = 59, PurchaseId = 30, ProductId = 1, Quantity = 1 },
    new PurchaseProduct { Id = 60, PurchaseId = 30, ProductId = 3, Quantity = 5 }
);


    }
}