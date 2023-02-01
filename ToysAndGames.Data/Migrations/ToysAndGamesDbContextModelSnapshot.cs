﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToysAndGames.Data;

#nullable disable

namespace ToysAndGames.Data.Migrations
{
    [DbContext(typeof(ToysAndGamesDbContext))]
    partial class ToysAndGamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToysAndGames.Data.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mattel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Disney"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lego"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fisher-Price"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bandai"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hasbro"
                        });
                });

            modelBuilder.Entity("ToysAndGames.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRestriction = 6,
                            CompanyId = 1,
                            Description = "Matchbox Work Team Pack 4 cars",
                            Name = "Match box2",
                            Price = 125m
                        },
                        new
                        {
                            Id = 2,
                            AgeRestriction = 3,
                            CompanyId = 3,
                            Description = "Display base for the Mandalorian LEGO Star Wars minifigures",
                            Name = "The Razor Crest2",
                            Price = 3000m
                        },
                        new
                        {
                            Id = 3,
                            AgeRestriction = 3,
                            CompanyId = 6,
                            Description = "Potato Head - Mr. Potato Head",
                            Name = "Potato Head",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 4,
                            AgeRestriction = 6,
                            CompanyId = 5,
                            Description = "DC Comics Stylized Superman",
                            Name = "Superman 2",
                            Price = 524m
                        });
                });

            modelBuilder.Entity("ToysAndGames.Data.Models.Product", b =>
                {
                    b.HasOne("ToysAndGames.Data.Models.Company", "Companies")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ToysAndGames.Data.Models.Company", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
