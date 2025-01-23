using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequioDemoTrack.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Group = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenderValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    Pack = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RaceValue = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    AgeGroupId = table.Column<int>(type: "integer", nullable: false),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AgeGroups_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AgeGroups",
                columns: new[] { "Id", "Group" },
                values: new object[,]
                {
                    { 1, "18-24" },
                    { 2, "25-34" },
                    { 3, "35-44" },
                    { 4, "45-54" },
                    { 5, "55-64" },
                    { 6, "65-74" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d7f5e876-91fe-4e0b-a2c9-e6a07500f50e", 0, "95fcd0f0-aa36-4d66-bccf-05624986f339", "jordan@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMSoh4PRmeXxAaaFwd9jw9C51btce0z/OmUpzOvKDUlHO9YHuQv/by8p6te1EyS3lA==", null, false, "9249f3d1-1bca-42bd-81f7-aafa501a1617", false, "SmithJordan" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "1bf76715-faa1-440f-8b6f-bdd1bdf1b55f", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEH9hF/GiYHtuVCqSE8ZnXF19z7s7AlWCrnkzdY7tHLW/v0BtlIWku6JM94ISAwPIWg==", null, false, "89183072-0c98-4b35-b23c-cef47f73dd1a", false, "Administrator" },
                    { "f7b45b7d-3c74-4dfd-a8f9-20fe7b8cb062", 0, "16c0a99b-9f4e-4bb7-8f16-a958663b2786", "taylor@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEM0RcbH72P6K2LI5rW7nZC2Hns6/+blFVuS9XQeJomXcwrIzsZn3w8Ou3VHXEgR/eg==", null, false, "ac74f04e-ab4a-48fd-8813-793e6dd1da8f", false, "JohnsonTaylor" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderValue" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Non-binary" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationValue" },
                values: new object[,]
                {
                    { 1, "Downtown LA" },
                    { 2, "Hollywood" },
                    { 3, "Beverly Hills" },
                    { 4, "Santa Monica" },
                    { 5, "Venice" },
                    { 6, "Pasadena" },
                    { 7, "Westwood" },
                    { 8, "Silver Lake" },
                    { 9, "Echo Park" },
                    { 10, "Culver City" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Ingredients", "Name", "Pack", "Price" },
                values: new object[,]
                {
                    { 1, "/Blanco.png", "El Mexicano® Tequila Blanco (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", "Sparkling Blanco", 8, 39.98m },
                    { 2, "/Blanco.png", "El Mexicano® Tequila Blanco (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", "Sparkling Blanco", 24, 119.94m },
                    { 3, "/Repasado.png", "El Mexicano® Tequila Repasado (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", "Sparkling Repasado", 8, 39.98m },
                    { 4, "/Repasado.png", "El Mexicano® Tequila Repasado (Certified Additive-Free, 100% De Agave), Sparkling Water, Natural Lime Flavor, Citric Acid", "Sparkling Repasado", 24, 119.94m }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "RaceValue" },
                values: new object[,]
                {
                    { 1, "Asian" },
                    { 2, "Black" },
                    { 3, "White" },
                    { 4, "Hispanic" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "AgeGroupId", "Email", "GenderId", "LocationId", "Name", "RaceId" },
                values: new object[,]
                {
                    { 1, "123 Main St, Downtown LA", 1, "john.doe@example.com", 1, 1, "John Doe", 1 },
                    { 2, "456 Elm St, Hollywood", 2, "jane.smith@example.com", 2, 2, "Jane Smith", 2 },
                    { 3, "789 Oak St, Beverly Hills", 3, "mark.brown@example.com", 1, 3, "Mark Brown", 3 },
                    { 4, "111 Maple Ave, Santa Monica", 4, "emily.davis@example.com", 2, 4, "Emily Davis", 4 },
                    { 5, "222 Pine St, Venice", 5, "michael.wilson@example.com", 3, 5, "Michael Wilson", 1 },
                    { 6, "333 Cedar Rd, Pasadena", 6, "sarah.johnson@example.com", 2, 6, "Sarah Johnson", 2 },
                    { 7, "444 Birch Ln, Westwood", 1, "david.lee@example.com", 3, 7, "David Lee", 3 },
                    { 8, "555 Willow Dr, Silver Lake", 2, "jessica.white@example.com", 1, 8, "Jessica White", 4 },
                    { 9, "666 Vine St, Echo Park", 3, "james.miller@example.com", 3, 9, "James Miller", 1 },
                    { 10, "777 Redwood St, Culver City", 4, "laura.moore@example.com", 2, 10, "Laura Moore", 2 },
                    { 11, "888 Laurel St, Downtown LA", 5, "robert.clark@example.com", 1, 1, "Robert Clark", 3 },
                    { 12, "999 Cherry Ave, Hollywood", 6, "linda.martinez@example.com", 2, 2, "Linda Martinez", 4 },
                    { 13, "123 Cypress Ln, Beverly Hills", 1, "charles.garcia@example.com", 3, 3, "Charles Garcia", 1 },
                    { 14, "456 Magnolia Blvd, Santa Monica", 2, "sophia.rodriguez@example.com", 1, 4, "Sophia Rodriguez", 2 },
                    { 15, "789 Dogwood St, Venice", 3, "daniel.hall@example.com", 3, 5, "Daniel Hall", 3 },
                    { 16, "111 Fir St, Pasadena", 4, "olivia.lopez@example.com", 2, 6, "Olivia Lopez", 4 },
                    { 17, "222 Ash St, Westwood", 5, "paul.hernandez@example.com", 1, 7, "Paul Hernandez", 1 },
                    { 18, "333 Palm Ave, Silver Lake", 6, "anna.king@example.com", 2, 8, "Anna King", 2 },
                    { 19, "444 Fir Ln, Echo Park", 1, "steven.wright@example.com", 3, 9, "Steven Wright", 3 },
                    { 20, "555 Oak Blvd, Culver City", 2, "megan.scott@example.com", 1, 10, "Megan Scott", 4 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "IsActive", "LastName", "StartDate" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", false, "Strator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "202 Oak Avenue", "Jordan", "d7f5e876-91fe-4e0b-a2c9-e6a07500f50e", false, "Smith", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "303 Pine Street", "Taylor", "f7b45b7d-3c74-4dfd-a8f9-20fe7b8cb062", false, "Johnson", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CustomerId", "PurchaseDate", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 3, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 5, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 7, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 9, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 2, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 4, new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 6, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 8, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 10, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 3, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, 5, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, 7, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, 9, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, 2, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 4, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 6, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, 8, new DateTime(2024, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, 10, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, 1, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, 3, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, 5, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, 7, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, 9, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 26, 2, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, 4, new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, 6, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, 8, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 30, 10, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseProducts",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 3, 1, 1 },
                    { 3, 2, 2, 3 },
                    { 4, 1, 2, 1 },
                    { 5, 3, 3, 2 },
                    { 6, 2, 3, 1 },
                    { 7, 1, 4, 3 },
                    { 8, 2, 4, 2 },
                    { 9, 3, 5, 1 },
                    { 10, 1, 5, 4 },
                    { 11, 2, 6, 2 },
                    { 12, 3, 6, 3 },
                    { 13, 1, 7, 1 },
                    { 14, 2, 7, 3 },
                    { 15, 3, 8, 2 },
                    { 16, 1, 8, 5 },
                    { 17, 2, 9, 4 },
                    { 18, 3, 9, 1 },
                    { 19, 1, 10, 2 },
                    { 20, 2, 10, 3 },
                    { 21, 3, 11, 1 },
                    { 22, 2, 11, 2 },
                    { 23, 1, 12, 3 },
                    { 24, 3, 12, 2 },
                    { 25, 2, 13, 4 },
                    { 26, 1, 13, 1 },
                    { 27, 3, 14, 3 },
                    { 28, 2, 14, 2 },
                    { 29, 1, 15, 2 },
                    { 30, 3, 15, 1 },
                    { 31, 2, 16, 5 },
                    { 32, 1, 16, 3 },
                    { 33, 3, 17, 2 },
                    { 34, 2, 17, 4 },
                    { 35, 1, 18, 3 },
                    { 36, 3, 18, 2 },
                    { 37, 2, 19, 4 },
                    { 38, 1, 19, 1 },
                    { 39, 3, 20, 5 },
                    { 40, 2, 20, 3 },
                    { 41, 1, 21, 1 },
                    { 42, 3, 21, 2 },
                    { 43, 2, 22, 5 },
                    { 44, 1, 22, 2 },
                    { 45, 3, 23, 3 },
                    { 46, 2, 23, 1 },
                    { 47, 1, 24, 4 },
                    { 48, 3, 24, 2 },
                    { 49, 2, 25, 3 },
                    { 50, 1, 25, 1 },
                    { 51, 3, 26, 2 },
                    { 52, 2, 26, 4 },
                    { 53, 1, 27, 3 },
                    { 54, 3, 27, 2 },
                    { 55, 2, 28, 5 },
                    { 56, 1, 28, 4 },
                    { 57, 3, 29, 3 },
                    { 58, 2, 29, 2 },
                    { 59, 1, 30, 1 },
                    { 60, 3, 30, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AgeGroupId",
                table: "Customers",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GenderId",
                table: "Customers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RaceId",
                table: "Customers",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_ProductId",
                table: "PurchaseProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserProfileId",
                table: "Purchases",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PurchaseProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
