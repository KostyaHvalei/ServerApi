﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ServerApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
