﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APINetBorker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231102094339_NewDBase")]
    partial class NewDBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Core.Entities.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Contract.Contact", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "aaaa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "bbbb"
                        },
                        new
                        {
                            Id = 3,
                            Name = "cccc"
                        },
                        new
                        {
                            Id = 4,
                            Name = "dddd"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ffff"
                        });
                });

            modelBuilder.Entity("Core.Entities.Contract.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillingChargeType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BillingType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CloserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrollmentType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FronterId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LegalEntityName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PricingType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CloserId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FronterId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BillingChargeType = 0,
                            BillingType = 0,
                            CloserId = 1,
                            ContactId = 1,
                            CustomerId = 1,
                            EnrollmentType = 0,
                            FronterId = 1,
                            IsActive = true,
                            LegalEntityName = "a",
                            PricingType = 0,
                            SoldDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stage = 0,
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 2,
                            BillingChargeType = 0,
                            BillingType = 0,
                            CloserId = 2,
                            ContactId = 2,
                            CustomerId = 2,
                            EnrollmentType = 0,
                            FronterId = 2,
                            IsActive = true,
                            LegalEntityName = "b",
                            PricingType = 0,
                            SoldDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stage = 0,
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 3,
                            BillingChargeType = 0,
                            BillingType = 0,
                            CloserId = 3,
                            ContactId = 3,
                            CustomerId = 3,
                            EnrollmentType = 0,
                            FronterId = 3,
                            IsActive = true,
                            LegalEntityName = "c",
                            PricingType = 0,
                            SoldDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stage = 0,
                            SupplierId = 3
                        },
                        new
                        {
                            Id = 4,
                            BillingChargeType = 0,
                            BillingType = 0,
                            CloserId = 4,
                            ContactId = 4,
                            CustomerId = 4,
                            EnrollmentType = 0,
                            FronterId = 4,
                            IsActive = true,
                            LegalEntityName = "d",
                            PricingType = 0,
                            SoldDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stage = 0,
                            SupplierId = 4
                        },
                        new
                        {
                            Id = 5,
                            BillingChargeType = 0,
                            BillingType = 0,
                            CloserId = 5,
                            ContactId = 5,
                            CustomerId = 5,
                            EnrollmentType = 0,
                            FronterId = 5,
                            IsActive = true,
                            LegalEntityName = "f",
                            PricingType = 0,
                            SoldDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Stage = 0,
                            SupplierId = 5
                        });
                });

            modelBuilder.Entity("Core.Entities.Contract.ContractItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<decimal?>("Adder")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AnnualUsage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContractsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnergyUnitType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TermMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UtilityAccountNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContractsId");

                    b.ToTable("ContractItems");
                });

            modelBuilder.Entity("Core.Entities.Contract.Customer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "aaa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "bbb"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ccc"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ddd"
                        },
                        new
                        {
                            Id = 5,
                            Name = "fff"
                        });
                });

            modelBuilder.Entity("Core.Entities.Contract.Supplier", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "a"
                        },
                        new
                        {
                            Id = 2,
                            Name = "b"
                        },
                        new
                        {
                            Id = 3,
                            Name = "c"
                        },
                        new
                        {
                            Id = 4,
                            Name = "d"
                        },
                        new
                        {
                            Id = 5,
                            Name = "e"
                        });
                });

            modelBuilder.Entity("Core.Entities.Contract.SupplierDeposit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SupplierId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("SupplierId1");

                    b.ToTable("SupplierDeposit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1m,
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SupplierId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2m,
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SupplierId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 3m,
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SupplierId = 3
                        },
                        new
                        {
                            Id = 4,
                            Amount = 4m,
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SupplierId = 4
                        },
                        new
                        {
                            Id = 5,
                            Amount = 5m,
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SupplierId = 5
                        });
                });

            modelBuilder.Entity("Core.Entities.Sales.Commision", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("CommissionConfigurationTypeId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DateConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("MarginPercent")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ProgramAdder")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProgramAdderType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SalesProgramId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DateConfigId");

                    b.HasIndex("SalesProgramId");

                    b.ToTable("Commision");
                });

            modelBuilder.Entity("Core.Entities.Sales.DateConfig", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int?>("CommisionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ControlDateModifierType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ControlDateOffsetType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ControlDateOffsetValue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ControlDateType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CommisionId");

                    b.ToTable("DateConfigs");
                });

            modelBuilder.Entity("Core.Entities.Sales.Qualification", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FromAnnualUsage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SalesProgramId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ToAnnualUsage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SalesProgramId");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("Core.Entities.Sales.SalesProgram", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("EnergyUnitType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SalesProgramType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SalePrograms");
                });

            modelBuilder.Entity("Core.Entities.User.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT")
                        .HasComment("Maximum length for the full name is 255 characters");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Address = "DN",
                            BirthDay = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "b54a974f-55f8-44aa-bb6b-8ef10c224379",
                            DateCreated = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "MrDat",
                            IsActive = true,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Address = "HCM",
                            BirthDay = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e0aec063-1409-440d-8c35-7f0abbbd4dea",
                            DateCreated = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "MrD",
                            IsActive = true,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Address = "HN",
                            BirthDay = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "fbe16813-63ca-4c19-850c-24f9f1cce89c",
                            DateCreated = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "MrB",
                            IsActive = true,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            Address = "QN",
                            BirthDay = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "4712faae-31a3-427a-bcc6-6846101fc025",
                            DateCreated = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "MrC",
                            IsActive = true,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            Address = "HT",
                            BirthDay = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "ac45ac71-8b3f-48f5-967d-94796b268095",
                            DateCreated = new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FullName = "MrD",
                            IsActive = true,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Contract.Contract", b =>
                {
                    b.HasOne("Core.Entities.User.ApplicationUser", null)
                        .WithMany("Contracts")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Core.Entities.User.ApplicationUser", "Closer")
                        .WithMany()
                        .HasForeignKey("CloserId");

                    b.HasOne("Core.Entities.Contract.Contact", "Contact")
                        .WithMany("Contracts")
                        .HasForeignKey("ContactId");

                    b.HasOne("Core.Entities.Contract.Customer", "Customer")
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Core.Entities.User.ApplicationUser", "Fronter")
                        .WithMany()
                        .HasForeignKey("FronterId");

                    b.HasOne("Core.Entities.Contract.Supplier", "Supplier")
                        .WithMany("Contracts")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Closer");

                    b.Navigation("Contact");

                    b.Navigation("Customer");

                    b.Navigation("Fronter");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Core.Entities.Contract.ContractItem", b =>
                {
                    b.HasOne("Core.Entities.Contract.Contract", "Contracts")
                        .WithMany("ContractItems")
                        .HasForeignKey("ContractsId");

                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Core.Entities.Contract.SupplierDeposit", b =>
                {
                    b.HasOne("Core.Entities.Contract.Supplier", "Suppliers")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.HasOne("Core.Entities.Contract.Supplier", null)
                        .WithMany("SupplierDeposits")
                        .HasForeignKey("SupplierId1");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Core.Entities.Sales.Commision", b =>
                {
                    b.HasOne("Core.Entities.Sales.DateConfig", "DateConfig")
                        .WithMany()
                        .HasForeignKey("DateConfigId");

                    b.HasOne("Core.Entities.Sales.SalesProgram", "SalesProgram")
                        .WithMany("Commisions")
                        .HasForeignKey("SalesProgramId");

                    b.Navigation("DateConfig");

                    b.Navigation("SalesProgram");
                });

            modelBuilder.Entity("Core.Entities.Sales.DateConfig", b =>
                {
                    b.HasOne("Core.Entities.Sales.Commision", "Commision")
                        .WithMany()
                        .HasForeignKey("CommisionId");

                    b.Navigation("Commision");
                });

            modelBuilder.Entity("Core.Entities.Sales.Qualification", b =>
                {
                    b.HasOne("Core.Entities.Sales.SalesProgram", "SalesProgram")
                        .WithMany("Qualifications")
                        .HasForeignKey("SalesProgramId");

                    b.Navigation("SalesProgram");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Core.Entities.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Core.Entities.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Core.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Core.Entities.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Contract.Contact", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Core.Entities.Contract.Contract", b =>
                {
                    b.Navigation("ContractItems");
                });

            modelBuilder.Entity("Core.Entities.Contract.Customer", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Core.Entities.Contract.Supplier", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("SupplierDeposits");
                });

            modelBuilder.Entity("Core.Entities.Sales.SalesProgram", b =>
                {
                    b.Navigation("Commisions");

                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("Core.Entities.User.ApplicationUser", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
