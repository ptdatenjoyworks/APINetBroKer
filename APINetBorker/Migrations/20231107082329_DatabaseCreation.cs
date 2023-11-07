using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APINetBorker.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
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
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SalesProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FromAnnualUsage = table.Column<int>(type: "INTEGER", nullable: true),
                    ToAnnualUsage = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualification_SalePrograms_SalesProgramId",
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
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BillingChargeType = table.Column<int>(type: "INTEGER", nullable: false),
                    BillingType = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentType = table.Column<int>(type: "INTEGER", nullable: false),
                    PricingType = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "SupplierDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    SupplierId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierDeposit_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierDeposit_Suppliers_SupplierId1",
                        column: x => x.SupplierId1,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractsId = table.Column<int>(type: "INTEGER", nullable: true),
                    UtilityAccountNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TermMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: true),
                    EnergyUnitType = table.Column<int>(type: "INTEGER", nullable: true),
                    AnnualUsage = table.Column<int>(type: "INTEGER", nullable: true),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: true),
                    Adder = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItems_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SalesProgramId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateConfigId = table.Column<int>(type: "INTEGER", nullable: true),
                    CommissionConfigurationTypeId = table.Column<string>(type: "TEXT", nullable: true),
                    ProgramAdderType = table.Column<int>(type: "INTEGER", nullable: false),
                    ProgramAdder = table.Column<decimal>(type: "TEXT", nullable: true),
                    MarginPercent = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commision_SalePrograms_SalesProgramId",
                        column: x => x.SalesProgramId,
                        principalTable: "SalePrograms",
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
                    ControlDateOffsetValue = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateConfigs_Commision_CommisionId",
                        column: x => x.CommisionId,
                        principalTable: "Commision",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDay", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "DN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "d774238f-6700-4e7f-92fe-dc7eefe2f31f", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrDat", true, false, null, null, null, null, null, false, null, false, null },
                    { 2, 0, "HCM", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "a29717f4-8c81-4a1f-98ce-2e06d3026a16", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrD", true, false, null, null, null, null, null, false, null, false, null },
                    { 3, 0, "HN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "abffcd8b-ebcb-45ce-a910-e6401ecef676", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrB", true, false, null, null, null, null, null, false, null, false, null },
                    { 4, 0, "QN", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "1ca9af26-37e3-4592-ab13-eeec97376c05", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrC", true, false, null, null, null, null, null, false, null, false, null },
                    { 5, 0, "HT", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf328916-32af-4d98-9b7e-b98754ad5e1d", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MrD", true, false, null, null, null, null, null, false, null, false, null }
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
                table: "Suppliers",
                columns: new[] { "Id", "IsActive", "Name", "Stage" },
                values: new object[,]
                {
                    { 1, true, "a", 0 },
                    { 2, true, "b", 0 },
                    { 3, true, "c", 0 },
                    { 4, true, "d", 0 },
                    { 5, true, "e", 0 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ApplicationUserId", "BillingChargeType", "BillingType", "CloserId", "ContactId", "CustomerId", "EnrollmentType", "FronterId", "IsActive", "LegalEntityName", "PricingType", "SoldDate", "Stage", "SupplierId" },
                values: new object[,]
                {
                    { 1, null, 0, 0, 1, 1, 1, 0, 1, true, "a", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, null, 0, 0, 2, 2, 2, 0, 2, true, "b", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2 },
                    { 3, null, 0, 0, 3, 3, 3, 0, 3, true, "c", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 4, null, 0, 0, 4, 4, 4, 0, 4, true, "d", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 },
                    { 5, null, 0, 0, 5, 5, 5, 0, 5, true, "f", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 }
                });

            migrationBuilder.InsertData(
                table: "SupplierDeposit",
                columns: new[] { "Id", "Amount", "PaymentDate", "SupplierId", "SupplierId1" },
                values: new object[,]
                {
                    { 1, 1m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { 2, 2m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, 3m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 4, 4m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 5, 5m, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null }
                });

            migrationBuilder.InsertData(
                table: "ContractItems",
                columns: new[] { "Id", "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "IsActive", "ProductType", "Rate", "Stage", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[,]
                {
                    { 1, 1m, 1, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 1, 1m, 0, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 2, 1m, 1, 2, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2, 1m, 0, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 3, 1m, 1, 3, new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2, 1m, 0, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 4, 1m, 1, 4, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 1, 1m, 0, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 5, 1m, 1, 5, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 1, 1m, 0, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5 }
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
                name: "IX_Commision_DateConfigId",
                table: "Commision",
                column: "DateConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Commision_SalesProgramId",
                table: "Commision",
                column: "SalesProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_ContractsId",
                table: "ContractItems",
                column: "ContractsId");

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
                column: "CommisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_SalesProgramId",
                table: "Qualification",
                column: "SalesProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeposit_SupplierId",
                table: "SupplierDeposit",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeposit_SupplierId1",
                table: "SupplierDeposit",
                column: "SupplierId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commision_DateConfigs_DateConfigId",
                table: "Commision",
                column: "DateConfigId",
                principalTable: "DateConfigs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commision_DateConfigs_DateConfigId",
                table: "Commision");

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
                name: "ContractItems");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "SupplierDeposit");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "DateConfigs");

            migrationBuilder.DropTable(
                name: "Commision");

            migrationBuilder.DropTable(
                name: "SalePrograms");
        }
    }
}
