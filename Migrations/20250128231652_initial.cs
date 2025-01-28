using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequioDemoTrack.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    { "d7f5e876-91fe-4e0b-a2c9-e6a07500f50e", 0, "4a6612c2-102f-4500-ab5b-50effb17ee1e", "jordan@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEE2bZcC2Wnb5gZiF558uehuv4tpkxt1nT07EKe70NJZqvFYvYLNAKWLKBYQM8SVKLg==", null, false, "6d5f36a7-cfe1-43f4-91dc-3f0d85d0fc9d", false, "SmithJordan" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "4c977c52-bd60-4290-bff5-99d053e500b3", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAELsz8ukGqczRfY3L2ModpSNGvR8QPoDcAB8j8i1OANZ1tw8fUrnwNW30ChpHmlnjhQ==", null, false, "29aa9889-9db1-418d-8d6d-441521af05b2", false, "Administrator" },
                    { "f7b45b7d-3c74-4dfd-a8f9-20fe7b8cb062", 0, "f7e7c53d-7563-4553-8d1d-08a08b7524ff", "taylor@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKdMrGILze1z+0rwFWBmYHjtXwAeATmVbQkzW3A9vC/WRpb4FeuriYRosZ43bHIWhA==", null, false, "c1b8295b-2a6e-44f0-b607-0605a0ecc808", false, "JohnsonTaylor" }
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
                    { 1, "38016 Francisco Way, Kuvalisfort, Slovenia", 3, "Joseph5@gmail.com", 3, 5, "Bernadette Stokes", 1 },
                    { 2, "6829 Brent Valley, Homenickstad, Thailand", 5, "Rudolph.Streich@gmail.com", 2, 8, "Freeman Abernathy", 2 },
                    { 3, "37822 Heathcote Oval, North Nestorshire, Israel", 6, "Alanis45@yahoo.com", 1, 3, "Foster Hilpert", 3 },
                    { 4, "285 Toy Flat, Port Zena, Faroe Islands", 2, "Cassie_Lesch@hotmail.com", 2, 1, "Merritt Gutkowski", 1 },
                    { 5, "5684 Wisoky Station, West Vicky, Kiribati", 4, "Prudence80@gmail.com", 1, 8, "Ross Stroman", 3 },
                    { 6, "365 Cassin Road, East Alan, Germany", 5, "Madyson_Weimann30@gmail.com", 1, 1, "Lorine Skiles", 2 },
                    { 7, "99590 Spencer Plain, West Rainatown, Denmark", 4, "Felix.Wuckert51@gmail.com", 2, 3, "Marge Nader", 2 },
                    { 8, "0918 Madonna Ville, West Berry, Peru", 5, "Joesph61@yahoo.com", 1, 1, "Katelynn Corwin", 2 },
                    { 9, "852 Herman Ville, North Carissaburgh, Western Sahara", 6, "Raoul.Marquardt34@yahoo.com", 2, 9, "Dortha Volkman", 2 },
                    { 10, "2793 Wunsch View, Hazelchester, Switzerland", 2, "Hilbert_Streich71@gmail.com", 3, 5, "Jadyn King", 4 },
                    { 11, "566 Otho Drives, Port Hildaborough, Serbia", 5, "Donny84@yahoo.com", 3, 1, "Miller Goyette", 1 },
                    { 12, "4807 Schneider Lock, North Jaclynfurt, Netherlands", 4, "Karina.Grant50@hotmail.com", 3, 6, "Kayleigh King", 3 },
                    { 13, "501 Collins Radial, North Jabari, Ethiopia", 6, "Zackary_Lehner44@hotmail.com", 2, 2, "Gerhard Klocko", 4 },
                    { 14, "34742 Bo Haven, Port Eda, China", 2, "Donavon.Langworth71@yahoo.com", 3, 5, "Maud Yundt", 4 },
                    { 15, "3621 Zieme Lake, New Davontebury, Gabon", 1, "Karianne98@gmail.com", 3, 3, "Pablo Maggio", 3 },
                    { 16, "103 Gudrun Island, North Nathanaelmouth, Latvia", 1, "Dante.Crooks@yahoo.com", 2, 1, "Delphia Ankunding", 4 },
                    { 17, "323 Haley Viaduct, Alvachester, El Salvador", 3, "Llewellyn_Murray@gmail.com", 1, 5, "Dorthy Collins", 2 },
                    { 18, "32607 Carlotta Trace, Brownton, Netherlands Antilles", 3, "Easton_Cormier@gmail.com", 1, 6, "Kaitlyn Heller", 1 },
                    { 19, "263 Emmett Burg, Jonesburgh, Jamaica", 1, "Rhett4@gmail.com", 1, 10, "Bailey Spencer", 4 },
                    { 20, "92369 Bartoletti Cliff, Monahanport, Kazakhstan", 2, "Bernadine_Koch32@gmail.com", 1, 8, "Kole Donnelly", 1 },
                    { 21, "0777 Zemlak Walk, South Araceli, Gambia", 5, "Korey.Auer@gmail.com", 2, 9, "Dulce Larkin", 1 },
                    { 22, "973 Emma Freeway, Jaskolskitown, Australia", 1, "Raven.Reichel60@hotmail.com", 1, 6, "Retta Kunze", 1 },
                    { 23, "22609 Johns Landing, Granvillefort, Guam", 3, "Madie_Mayert69@hotmail.com", 1, 5, "Issac Kunze", 4 },
                    { 24, "34545 Mueller Pine, Lake Vella, Andorra", 3, "Wilfredo75@yahoo.com", 1, 3, "Tillman Paucek", 2 },
                    { 25, "1204 Johnson Grove, West Julie, San Marino", 3, "Marcel77@hotmail.com", 1, 2, "Jayson Beier", 1 },
                    { 26, "0548 Lexi Road, New Tomas, Trinidad and Tobago", 4, "Carlee.Windler@hotmail.com", 2, 6, "Dejuan Purdy", 1 },
                    { 27, "4537 Lesch Mountain, Blandaview, Turkey", 1, "Connor61@hotmail.com", 1, 7, "Shyanne Mertz", 1 },
                    { 28, "28936 Adams Lodge, Ankundingtown, Aruba", 5, "Buford.Kautzer@gmail.com", 3, 1, "Lue Bartell", 4 },
                    { 29, "892 Olen Mill, New Justinaburgh, India", 4, "Scottie24@gmail.com", 2, 10, "Jocelyn Waters", 2 },
                    { 30, "1181 Willms Street, Christophemouth, Austria", 3, "Libby.Paucek@gmail.com", 2, 2, "Elda Schamberger", 1 },
                    { 31, "22759 Justice Crescent, Wardhaven, Guinea", 6, "Kirsten_Morissette@yahoo.com", 3, 2, "Antonio Beer", 4 },
                    { 32, "87030 Madisyn Plain, New Amayaton, Saint Helena", 1, "Maximo.Senger@gmail.com", 3, 7, "Meredith Hintz", 2 },
                    { 33, "96087 Ernestine Roads, Howeport, Burkina Faso", 4, "Viola_Kuhn34@gmail.com", 1, 1, "Cindy Paucek", 1 },
                    { 34, "286 Callie Shore, Stonestad, Iraq", 4, "Geovany_OConnell72@hotmail.com", 3, 3, "Russ Weber", 3 },
                    { 35, "7949 Alfreda Valleys, Schoenville, Bulgaria", 5, "Selmer1@hotmail.com", 3, 8, "Gregoria Leuschke", 2 },
                    { 36, "4289 Kunze Orchard, Lake Javonside, Grenada", 5, "Devante_Lueilwitz@hotmail.com", 3, 6, "Casimir Wunsch", 2 },
                    { 37, "021 Cummings Walk, Hanebury, Malawi", 6, "Lola87@yahoo.com", 2, 10, "Earnest Larson", 2 },
                    { 38, "523 Reyna Brook, Jerelport, Ukraine", 4, "Braulio.Renner58@gmail.com", 1, 1, "Braxton Kuvalis", 2 },
                    { 39, "633 Conn Crossroad, East Jaylan, Seychelles", 3, "Ernesto.Aufderhar0@yahoo.com", 1, 2, "Hilario Morar", 3 },
                    { 40, "36189 Shields Mountains, Kuphalmouth, Bouvet Island (Bouvetoya)", 3, "Nikolas28@gmail.com", 1, 2, "Janick Considine", 3 },
                    { 41, "6725 Kip Throughway, Greggton, Western Sahara", 3, "Bryce_Pagac@hotmail.com", 1, 8, "Claudine Wilderman", 1 },
                    { 42, "4124 Heathcote Trail, Lake Mariobury, Liechtenstein", 1, "Shany_White74@hotmail.com", 1, 2, "Gussie Yost", 4 },
                    { 43, "22814 Rylan Junctions, Denesikport, South Georgia and the South Sandwich Islands", 5, "Daphne89@hotmail.com", 1, 8, "Myah Turner", 4 },
                    { 44, "816 Neoma View, Hesterton, Nicaragua", 6, "Maryjane.Walter@hotmail.com", 1, 4, "Jason Murphy", 4 },
                    { 45, "63325 Hane Islands, North Ocie, Bosnia and Herzegovina", 3, "Gaetano_Jakubowski@gmail.com", 3, 5, "Guillermo Kemmer", 2 },
                    { 46, "3757 Boyer Forge, Vonland, India", 2, "Harold_Goodwin68@yahoo.com", 1, 10, "Laron Little", 1 },
                    { 47, "93956 Wolf Park, South Candicefurt, Somalia", 1, "Penelope80@gmail.com", 2, 9, "Burnice Quitzon", 3 },
                    { 48, "77957 Jared Extension, Lake Markusstad, United States Minor Outlying Islands", 6, "Zoie35@gmail.com", 3, 1, "Jamal Schoen", 3 },
                    { 49, "283 Andreanne Falls, Zemlaktown, Poland", 4, "Nova_Cole14@gmail.com", 2, 5, "Imogene Fay", 3 },
                    { 50, "5890 Corwin Mills, New Zetta, Tajikistan", 1, "Cathy.Kuvalis@gmail.com", 3, 8, "Sabrina Bergnaum", 4 },
                    { 51, "6230 Shaylee Islands, Jonesland, Egypt", 4, "Josh.Mraz@hotmail.com", 2, 8, "Eleanore Keeling", 4 },
                    { 52, "374 Ellsworth Loop, Starkburgh, American Samoa", 6, "Hailee15@hotmail.com", 1, 6, "Green Stehr", 4 },
                    { 53, "253 Lakin Wall, Clydeberg, Marshall Islands", 3, "Tressa_Wiegand@gmail.com", 3, 5, "Antone Schimmel", 3 },
                    { 54, "4288 Corwin Island, Domingoton, Liberia", 1, "Edd_Spencer79@yahoo.com", 1, 10, "Cortez Lueilwitz", 2 },
                    { 55, "7707 Champlin Manor, Giovanniport, Malaysia", 2, "Trisha.Fahey0@gmail.com", 2, 3, "Helene Beahan", 2 },
                    { 56, "406 Kovacek Skyway, Gregoryville, New Caledonia", 3, "Frederik.Emard@gmail.com", 3, 1, "Malinda Herman", 4 },
                    { 57, "67708 Johnny Lodge, South Minerva, Falkland Islands (Malvinas)", 3, "Kaden55@yahoo.com", 1, 6, "Lawson O'Keefe", 4 },
                    { 58, "965 Altenwerth Island, South Malliefurt, Ukraine", 3, "Xander83@hotmail.com", 3, 10, "Ollie Beier", 3 },
                    { 59, "401 Johns Mills, West Verda, Djibouti", 5, "Devyn_Hegmann50@gmail.com", 3, 3, "Elmira Kuhlman", 2 },
                    { 60, "1173 Grimes Locks, Lake Yasmine, Bosnia and Herzegovina", 2, "Ryder15@yahoo.com", 1, 9, "Brook Keebler", 4 },
                    { 61, "90870 Raphael Park, New Hermina, Heard Island and McDonald Islands", 2, "Orie_Herzog@yahoo.com", 1, 7, "Sadye Ortiz", 3 },
                    { 62, "108 Ortiz Pass, South Naomishire, Honduras", 3, "Josianne_Osinski@gmail.com", 3, 4, "Kathlyn Dare", 1 },
                    { 63, "024 Watsica Walk, Lianaside, South Africa", 2, "Tyrell.Ledner@yahoo.com", 1, 5, "Rhiannon Cartwright", 2 },
                    { 64, "0370 Leonie Forest, Lucileberg, Kiribati", 5, "Baby_Jaskolski@hotmail.com", 2, 4, "Aaliyah Ward", 3 },
                    { 65, "715 Emery Circle, North Marisolmouth, South Africa", 1, "Kaitlyn_Volkman86@yahoo.com", 1, 3, "Maximo Rath", 2 },
                    { 66, "088 Hannah Locks, Wilfridhaven, Senegal", 4, "Joshuah22@hotmail.com", 2, 9, "Adrian Bernier", 3 },
                    { 67, "1533 Jeff Viaduct, Yasminefort, Netherlands Antilles", 2, "Ward.Koss30@hotmail.com", 2, 7, "Eula Kling", 4 },
                    { 68, "8665 Legros Mount, Heathcotetown, Ukraine", 5, "Stefan71@gmail.com", 3, 6, "Beryl Emmerich", 4 },
                    { 69, "75382 Reilly Knoll, Douglasmouth, Bosnia and Herzegovina", 3, "Coty_Champlin@gmail.com", 1, 6, "Ansley Price", 4 },
                    { 70, "658 Moore Inlet, East Laceyside, Gambia", 6, "Zetta.Bayer32@gmail.com", 3, 5, "Paolo Marquardt", 4 },
                    { 71, "53363 Chaim Corners, Huelsfort, Indonesia", 5, "Cameron_OConner23@gmail.com", 2, 8, "Trinity Crona", 1 },
                    { 72, "31878 Shad Forges, Rowenaville, Lithuania", 1, "Guadalupe23@yahoo.com", 1, 10, "Agustina Kovacek", 4 },
                    { 73, "9812 Lockman Canyon, Lake Rafaela, Central African Republic", 3, "Jean.Heathcote96@gmail.com", 3, 8, "Virginie Stoltenberg", 3 },
                    { 74, "498 Nicolas Underpass, East Paulinemouth, Indonesia", 4, "Brendon.Schaden@yahoo.com", 2, 4, "Gabriel Kub", 2 },
                    { 75, "6070 Josie Station, South Nikoborough, Greece", 5, "Alicia14@yahoo.com", 3, 4, "Kira Terry", 2 },
                    { 76, "101 Dorothea Villages, Lake Adolphusmouth, Mali", 2, "Miller75@hotmail.com", 2, 8, "Zack Witting", 4 },
                    { 77, "964 Beier Unions, Ferneberg, New Zealand", 1, "Ruth68@hotmail.com", 1, 9, "Ariel Stanton", 2 },
                    { 78, "32028 Claudine Cape, Cassinborough, Uganda", 2, "Mark48@gmail.com", 1, 3, "Justina Buckridge", 4 },
                    { 79, "2464 Louie Pine, Heathcoteborough, Mongolia", 6, "Cornelius_Swaniawski3@hotmail.com", 1, 5, "Kareem Labadie", 4 },
                    { 80, "56058 Damon Knoll, Nathanialfurt, Sudan", 6, "Zander_Wuckert42@hotmail.com", 2, 9, "Armand Jenkins", 3 },
                    { 81, "19056 Sawayn Dam, West Oma, Saint Barthelemy", 4, "Colleen_Conroy8@yahoo.com", 1, 2, "Virginie Treutel", 4 },
                    { 82, "725 Jones Stream, South Ezequielstad, Gabon", 1, "Mossie_Bechtelar86@hotmail.com", 3, 7, "Pete Runolfsdottir", 1 },
                    { 83, "8691 Edwardo Unions, North Marinaville, Cyprus", 5, "Ronaldo.Macejkovic@gmail.com", 3, 7, "Lexus Terry", 2 },
                    { 84, "15310 Lucienne Village, West Opalville, Kenya", 5, "Dameon.Reynolds46@hotmail.com", 3, 4, "Rosario Carter", 2 },
                    { 85, "5087 Towne Locks, Port Haleighton, Madagascar", 3, "Timmy.Kohler@yahoo.com", 3, 8, "Eleonore Mayer", 3 },
                    { 86, "2665 Gussie Mountain, North Scarletttown, Poland", 3, "Jevon80@hotmail.com", 2, 3, "Carmine Lehner", 2 },
                    { 87, "19591 Skiles Ports, Garlandton, Kuwait", 5, "Abner.Shields@yahoo.com", 3, 10, "Morton Fay", 1 },
                    { 88, "15227 Grimes Land, Port Lexusbury, Macedonia", 5, "Lexi6@yahoo.com", 2, 6, "Sydni Stoltenberg", 2 },
                    { 89, "5403 Keagan Tunnel, Stromanshire, Marshall Islands", 1, "Natalie.Quitzon83@yahoo.com", 3, 3, "Nedra Sporer", 2 },
                    { 90, "52670 Price Underpass, New Elenorville, Macao", 5, "Zachariah.Borer@yahoo.com", 2, 4, "Lilian Schultz", 1 },
                    { 91, "79295 Maximillia Inlet, South Madilynbury, Puerto Rico", 6, "Annabell_Miller@yahoo.com", 3, 2, "Maida Bins", 2 },
                    { 92, "31428 Windler Locks, Mathildebury, Comoros", 6, "Mittie.OKon@hotmail.com", 1, 1, "Maxie Kassulke", 3 },
                    { 93, "0200 Neva Glen, Krajcikshire, Guernsey", 1, "Mellie.Dicki@gmail.com", 2, 10, "Agustin Wilkinson", 3 },
                    { 94, "63710 Dulce Islands, Hauckburgh, Mexico", 3, "Barrett.Cartwright62@yahoo.com", 2, 8, "Ernie Koelpin", 2 },
                    { 95, "6494 Lind Rapids, Lake Richmond, Liechtenstein", 3, "Archibald.Dietrich@yahoo.com", 3, 8, "Armando Lesch", 1 },
                    { 96, "383 Bergnaum Street, East Wilford, South Georgia and the South Sandwich Islands", 1, "Dereck5@gmail.com", 3, 1, "Lorenza Goodwin", 2 },
                    { 97, "755 Steuber Hollow, Carterland, United States Minor Outlying Islands", 2, "Nicolette_Daniel@yahoo.com", 3, 6, "Tressie Bernier", 4 },
                    { 98, "81637 VonRueden Road, Marksbury, Ghana", 4, "Tanner71@yahoo.com", 3, 4, "Giovani Bednar", 4 },
                    { 99, "836 Leuschke Route, Port Britneyland, Dominica", 4, "Josefina.Hackett71@gmail.com", 2, 9, "Buford Kuhn", 3 },
                    { 100, "833 Delia Mountains, North Myrticehaven, Belgium", 6, "Ashley_Harris@yahoo.com", 3, 10, "Myrl Block", 3 }
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
