﻿// <auto-generated />
using System;
using AcessaCity.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcessaCity.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AcessaCity.Business.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("IBGECode")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<Guid>("StateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ae590f1-c6a4-4bb3-91bf-1e82ea45bb4b"),
                            IBGECode = 3509502,
                            Latitude = -22.8920565m,
                            Longitude = -47.2079794m,
                            Name = "Campinas",
                            StateId = new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661")
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("Verified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("ZIPCode")
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CityHalls");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHallRelatedUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityHallId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CityHallId");

                    b.HasIndex("UserId");

                    b.ToTable("CityHallRelatedUser");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Denied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<bool>("InProgress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Review")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("ReportStatus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96afa0df-8ad9-4a44-a726-70582b7bd010"),
                            Approved = true,
                            Denied = false,
                            Description = "Aprovado",
                            InProgress = false,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("52ccae2e-af86-4fcc-82ea-9234088dbedf"),
                            Approved = false,
                            Denied = true,
                            Description = "Negado",
                            InProgress = false,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("c37d9588-1875-44dd-8cf1-6781de7533c3"),
                            Approved = false,
                            Denied = false,
                            Description = "Em progresso",
                            InProgress = true,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("48cf5f0f-40c9-4a79-9627-6fd22018f72c"),
                            Approved = false,
                            Denied = false,
                            Description = "Em análise",
                            InProgress = false,
                            Review = true
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("UFCode")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661"),
                            Name = "São Paulo",
                            UFCode = "SP"
                        },
                        new
                        {
                            Id = new Guid("2f0892c5-f505-4bbf-a363-52f9a6754259"),
                            Name = "Minas Gerais",
                            UFCode = "MG"
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("FirebaseUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.Category", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.City", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.State", "CityState")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHall", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHallRelatedUser", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.CityHall", "CityHall")
                        .WithMany("RelatedUsers")
                        .HasForeignKey("CityHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany("RelatedCityHalls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
