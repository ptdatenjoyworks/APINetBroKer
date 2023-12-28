using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOpendict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true, comment: "Maximum length for the full name is 255 characters"),
                    BirthDay = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Permission = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "TEXT", nullable: true),
                    ClientType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayNames = table.Column<string>(type: "TEXT", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "TEXT", nullable: true),
                    Permissions = table.Column<string>(type: "TEXT", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    RedirectUris = table.Column<string>(type: "TEXT", nullable: true),
                    Requirements = table.Column<string>(type: "TEXT", nullable: true),
                    Settings = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Descriptions = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayNames = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    Resources = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnergyUnitType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SalesProgramType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationId = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    Scopes = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SalesProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    CommissionConfigurationTypeId = table.Column<string>(type: "TEXT", nullable: true),
                    ProgramAdderType = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgramAdder = table.Column<decimal>(type: "TEXT", nullable: true),
                    MarginPercent = table.Column<decimal>(type: "TEXT", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commisions_SalePrograms_SalesProgramId",
                        column: x => x.SalesProgramId,
                        principalTable: "SalePrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SalesProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    FromAnnualUsage = table.Column<int>(type: "INTEGER", nullable: true),
                    ToAnnualUsage = table.Column<int>(type: "INTEGER", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifications_SalePrograms_SalesProgramId",
                        column: x => x.SalesProgramId,
                        principalTable: "SalePrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LegalEntityName = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: true),
                    CloserId = table.Column<int>(type: "INTEGER", nullable: true),
                    FronterId = table.Column<int>(type: "INTEGER", nullable: true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    SoldDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BillingChargeType = table.Column<int>(type: "INTEGER", nullable: false),
                    BillingType = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentType = table.Column<int>(type: "INTEGER", nullable: false),
                    PricingType = table.Column<int>(type: "INTEGER", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_CloserId",
                        column: x => x.CloserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_AspNetUsers_FronterId",
                        column: x => x.FronterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierDeposits_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationId = table.Column<string>(type: "TEXT", nullable: true),
                    AuthorizationId = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Payload = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReferenceId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DateConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommisionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ControlDateType = table.Column<int>(type: "INTEGER", nullable: false),
                    ControlDateModifierType = table.Column<int>(type: "INTEGER", nullable: false),
                    ControlDateOffsetType = table.Column<int>(type: "INTEGER", nullable: false),
                    ControlDateOffsetValue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateConfigs_Commisions_CommisionId",
                        column: x => x.CommisionId,
                        principalTable: "Commisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractsId = table.Column<int>(type: "INTEGER", nullable: true),
                    UtilityAccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TermMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: true),
                    EnergyUnitType = table.Column<int>(type: "INTEGER", nullable: true),
                    AnnualUsage = table.Column<int>(type: "INTEGER", nullable: true),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: true),
                    Adder = table.Column<decimal>(type: "TEXT", nullable: true),
                    SaleProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    SalesProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ForecastState = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractMargin = table.Column<decimal>(type: "TEXT", nullable: false),
                    PercentageOfContractMargin = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItems_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractItems_SalePrograms_SalesProgramId",
                        column: x => x.SalesProgramId,
                        principalTable: "SalePrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractItemAttchment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    ContractItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItemAttchment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItemAttchment_ContractItems_ContractItemId",
                        column: x => x.ContractItemId,
                        principalTable: "ContractItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractItemForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ForecastMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    ForecastYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ForecastMonthOfYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItemForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItemForecast_ContractItems_ContractItemId",
                        column: x => x.ContractItemId,
                        principalTable: "ContractItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "Permission", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "DN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "83b67b32-d106-4897-8ddb-c8088e45d954", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrDat", true, false, null, null, null, null, null, null, null, false, null, false, null },
                    { 2, 0, "HCM", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "033e0b80-2c40-49a9-9402-34017d7f195d", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrD", true, false, null, null, null, null, null, null, null, false, null, false, null },
                    { 3, 0, "HN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "06aec210-4369-42d9-9fd6-bdd0626ab6f3", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrB", true, false, null, null, null, null, null, null, null, false, null, false, null },
                    { 4, 0, "QN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "8831675b-de28-4bda-b3d7-f59811aca76a", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrC", true, false, null, null, null, null, null, null, null, false, null, false, null },
                    { 5, 0, "HT", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "09c6b2dd-6b13-429e-afdd-f53361c0fcc0", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrD", true, false, null, null, null, null, null, null, null, false, null, false, null },
                    { 6, 0, "HT", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "2edf0f36-203d-4608-8cfb-7907f11ec586", new DateTime(2023, 12, 27, 14, 19, 18, 948, DateTimeKind.Local).AddTicks(2485), null, false, "MrD", true, false, null, null, null, "dat123", null, "admin", null, false, null, false, "Dat" },
                    { 7, 0, "HT", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5bef410-8b34-4e6c-aba2-e3147af6b20d", new DateTime(2023, 12, 27, 14, 19, 18, 948, DateTimeKind.Local).AddTicks(2500), null, false, "MrD", true, false, null, null, null, "vn123", null, "contract:all", null, false, null, false, "VN" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "aaaa" },
                    { 2, "bbbb" },
                    { 3, "cccc" },
                    { 4, "dddd" },
                    { 5, "ffff" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "aaa" },
                    { 2, "bbb" },
                    { 3, "ccc" },
                    { 4, "ddd" },
                    { 5, "fff" }
                });

            migrationBuilder.InsertData(
                table: "SalePrograms",
                columns: new[] { "Id", "Description", "EnergyUnitType", "SalesProgramType" },
                values: new object[,]
                {
                    { 1, "50% contract upfront then residual", 4, "PercentageContractUpfront + PercentageContractResidual" },
                    { 2, "Forecast annual margin divided by four", 2, "QuarterlyUpfront" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "a" },
                    { 2, true, "b" },
                    { 3, true, "c" },
                    { 4, true, "d" },
                    { 5, true, "e" }
                });

            migrationBuilder.InsertData(
                table: "Commisions",
                columns: new[] { "Id", "CommissionConfigurationTypeId", "DiscountPercentage", "Discriminator", "MarginPercent", "ProgramAdder", "ProgramAdderType", "SalesProgramId" },
                values: new object[,]
                {
                    { 1, "ContractUpfront", 0m, "ContractUpfront", 0.5m, 0.007m, 1, 1 },
                    { 2, "PercentageContractResidual", 0m, "PercentageContractResidual", 0.5m, 0.007m, 1, 1 },
                    { 3, "QuarterlyUpfront", 0m, "QuarterlyUpfront", 0.5m, 0.007m, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ApplicationUserId", "BillingChargeType", "BillingType", "CloserId", "ContactId", "CustomerId", "EnrollmentType", "FronterId", "IsActive", "LegalEntityName", "PricingType", "SoldDate", "Stage", "StartDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1, 1, 1, 1, 1, true, "John A", 1, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 1 },
                    { 2, null, 1, 1, 2, 1, 1, 1, 2, true, "Jelly B", 1, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Discriminator", "EffectiveDate", "ExpiryDate", "SalesProgramId" },
                values: new object[,]
                {
                    { 1, "QualificationDate", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2199, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "QualificationDate", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Discriminator", "FromAnnualUsage", "SalesProgramId", "ToAnnualUsage" },
                values: new object[] { 3, "QualificationAnnualUsage", 50000, 2, 100000 });

            migrationBuilder.InsertData(
                table: "SupplierDeposits",
                columns: new[] { "Id", "Amount", "PaymentDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "ContractItems",
                columns: new[] { "Id", "Adder", "AnnualUsage", "ContractMargin", "ContractsId", "EndDate", "EnergyUnitType", "ForecastState", "IsActive", "PercentageOfContractMargin", "ProductType", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[,]
                {
                    { 1, 0.0075m, 58398, 0m, 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 0m, 1, 0.01275m, null, null, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 24, "9138014006" },
                    { 2, 0.073m, 12303, 0m, 1, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, true, 0m, 2, 0.2275m, null, null, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 16, "9138014006" },
                    { 3, 6.3m, 835, 0m, 1, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, true, 0m, 1, 23m, null, null, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12, "9138014006" },
                    { 4, 0.0073m, 160880, 0m, 1, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 0m, 1, 0.02275m, null, null, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, "9138014006" },
                    { 5, 0.083m, 89340, 0m, 1, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, true, 0m, 2, 0.3275m, null, null, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12, "9138014006" },
                    { 6, 0.003m, 36000, 0m, 2, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 0m, 1, 0.0225m, null, null, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 17, "177478640021" },
                    { 7, 0.073m, 4200, 0m, 2, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, true, 0m, 2, 2.275m, null, null, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14, "177478640021" },
                    { 8, 5.32m, 1500, 0m, 2, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, true, 0m, 1, 20.75m, null, null, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 16, "177478640021" },
                    { 9, 0.053m, 60000, 0m, 2, new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, true, 0m, 2, 0.1275m, null, null, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 18, "177478640021" },
                    { 10, 0.0033m, 15000, 0m, 2, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 0m, 1, 0.04275m, null, null, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, "177478640021" }
                });

            migrationBuilder.InsertData(
                table: "DateConfigs",
                columns: new[] { "Id", "CommisionId", "ControlDateModifierType", "ControlDateOffsetType", "ControlDateOffsetValue", "ControlDateType" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, 2, 1 },
                    { 2, 2, 0, 0, 0, 1 },
                    { 3, 3, 0, 0, 0, 1 }
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
                name: "IX_Commisions_SalesProgramId",
                table: "Commisions",
                column: "SalesProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItemAttchment_ContractItemId",
                table: "ContractItemAttchment",
                column: "ContractItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItemForecast_ContractItemId",
                table: "ContractItemForecast",
                column: "ContractItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_ContractsId",
                table: "ContractItems",
                column: "ContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_SalesProgramId",
                table: "ContractItems",
                column: "SalesProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ApplicationUserId",
                table: "Contracts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CloserId",
                table: "Contracts",
                column: "CloserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContactId",
                table: "Contracts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerId",
                table: "Contracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FronterId",
                table: "Contracts",
                column: "FronterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SupplierId",
                table: "Contracts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_DateConfigs_CommisionId",
                table: "DateConfigs",
                column: "CommisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_SalesProgramId",
                table: "Qualifications",
                column: "SalesProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeposits_SupplierId",
                table: "SupplierDeposits",
                column: "SupplierId");
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
                name: "ContractItemAttchment");

            migrationBuilder.DropTable(
                name: "ContractItemForecast");

            migrationBuilder.DropTable(
                name: "DateConfigs");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "SupplierDeposits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContractItems");

            migrationBuilder.DropTable(
                name: "Commisions");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "SalePrograms");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
