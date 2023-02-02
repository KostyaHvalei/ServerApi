﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ServerApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20221016160709_CreateSpMigration")]
    partial class CreateSpMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("Fridges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1fd5ea01-c9e9-4215-b844-fd66e80d3e79"),
                            FridgeModelId = new Guid("f4793a96-678a-4cae-a6a3-f7cc51a6b98c"),
                            Name = "Genady Gorin's fridge",
                            OwnerName = "Genady Gorin"
                        },
                        new
                        {
                            Id = new Guid("ae16b99d-85f3-4121-bdad-e704c29e3981"),
                            FridgeModelId = new Guid("f4793a96-678a-4cae-a6a3-f7cc51a6b98c"),
                            Name = "Kitchen",
                            OwnerName = "Some guy"
                        },
                        new
                        {
                            Id = new Guid("d447d5c7-3d61-495c-8d36-89c337e3a9ef"),
                            FridgeModelId = new Guid("24964f45-61f7-4f9c-9ab8-c4981ad6a252"),
                            Name = "Stolovaya n2"
                        },
                        new
                        {
                            Id = new Guid("8be43fc6-4398-4714-8794-edacee214946"),
                            FridgeModelId = new Guid("24964f45-61f7-4f9c-9ab8-c4981ad6a252"),
                            Name = "Stolovaya n3"
                        },
                        new
                        {
                            Id = new Guid("92bafc65-cc77-485c-9756-81ad0aaa8008"),
                            FridgeModelId = new Guid("e3130a06-9410-44c0-bc38-6145b5e60426"),
                            Name = "Mine fridge",
                            OwnerName = "Man who wants to become developer"
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4793a96-678a-4cae-a6a3-f7cc51a6b98c"),
                            Name = "Atalant b100",
                            Year = 2005
                        },
                        new
                        {
                            Id = new Guid("b6138124-9e39-4aaf-b039-5e149dd4c928"),
                            Name = "Samsung v32",
                            Year = 2021
                        },
                        new
                        {
                            Id = new Guid("24964f45-61f7-4f9c-9ab8-c4981ad6a252"),
                            Name = "Samsung k20",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("e3130a06-9410-44c0-bc38-6145b5e60426"),
                            Name = "Soyuz 1337",
                            Year = 1964
                        },
                        new
                        {
                            Id = new Guid("b4e73b10-115e-4371-b851-9cd08cd69740"),
                            Name = "Bosh c999",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProducts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e1a3a80-11b3-4add-af8d-7a8e6b33517a"),
                            FridgeId = new Guid("1fd5ea01-c9e9-4215-b844-fd66e80d3e79"),
                            ProductId = new Guid("94fea888-0773-4d71-988a-32185bf61eee"),
                            Quantity = 3
                        },
                        new
                        {
                            Id = new Guid("886a0a29-3ca8-4f35-af38-e8ca3ec6d2e1"),
                            FridgeId = new Guid("1fd5ea01-c9e9-4215-b844-fd66e80d3e79"),
                            ProductId = new Guid("70497196-fb2d-4e29-8f17-1c2068afd916"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("3ebf24a1-1c0f-45e2-b7ff-c80a119a53cb"),
                            FridgeId = new Guid("8be43fc6-4398-4714-8794-edacee214946"),
                            ProductId = new Guid("e5d96170-0301-459b-96f4-795a65783654"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("bfc256b5-a2f1-4021-abcb-03ba7a1686bc"),
                            FridgeId = new Guid("92bafc65-cc77-485c-9756-81ad0aaa8008"),
                            ProductId = new Guid("29f71e4f-161a-4dab-86af-e2f7aec1e2ba"),
                            Quantity = 10
                        },
                        new
                        {
                            Id = new Guid("41174222-9f3d-4a56-b422-4e9d01bb13b1"),
                            FridgeId = new Guid("ae16b99d-85f3-4121-bdad-e704c29e3981"),
                            ProductId = new Guid("297a1295-eb00-4447-bb88-5d9b69a1e1f1"),
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94fea888-0773-4d71-988a-32185bf61eee"),
                            DefaultQuantity = 6,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = new Guid("297a1295-eb00-4447-bb88-5d9b69a1e1f1"),
                            DefaultQuantity = 1,
                            Name = "Juice"
                        },
                        new
                        {
                            Id = new Guid("70497196-fb2d-4e29-8f17-1c2068afd916"),
                            DefaultQuantity = 10,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("e5d96170-0301-459b-96f4-795a65783654"),
                            DefaultQuantity = 10,
                            Name = "Carrot"
                        },
                        new
                        {
                            Id = new Guid("29f71e4f-161a-4dab-86af-e2f7aec1e2ba"),
                            DefaultQuantity = 2,
                            Name = "Chicken"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "016cce0a-94bf-458c-ad5c-6c1e1a3880a2",
                            ConcurrencyStamp = "4e2e8c5a-f53d-48d2-ad5b-b2f5e955c806",
                            Name = "Manager",
                            NormalizedName = "Manager"
                        },
                        new
                        {
                            Id = "68c3b10e-07e7-4a2e-9da1-40029dda2da5",
                            ConcurrencyStamp = "73dc75fa-89e5-4485-84ab-023a25f284b9",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.HasOne("Entities.Models.FridgeModel", "FridgeModel")
                        .WithMany()
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("Entities.Models.FridgeProduct", b =>
                {
                    b.HasOne("Entities.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
