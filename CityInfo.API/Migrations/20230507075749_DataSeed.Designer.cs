﻿// <auto-generated />
using CityInfo.API.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20230507075749_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "American city",
                            Name = "New York"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Indian City",
                            Name = "Hyderabad"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Isaraeilian city",
                            Name = "Jerusellam"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointsOfInterest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("cityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("cityId");

                    b.ToTable("pointsOfInterests");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Description = "Description",
                            Name = "Name",
                            cityId = 1
                        },
                        new
                        {
                            id = 2,
                            Description = "Description2",
                            Name = "Name2",
                            cityId = 1
                        },
                        new
                        {
                            id = 3,
                            Description = "Description",
                            Name = "Name",
                            cityId = 2
                        },
                        new
                        {
                            id = 4,
                            Description = "Description2",
                            Name = "Name2",
                            cityId = 2
                        },
                        new
                        {
                            id = 5,
                            Description = "Description",
                            Name = "Name",
                            cityId = 3
                        },
                        new
                        {
                            id = 6,
                            Description = "Description2",
                            Name = "Name2",
                            cityId = 3
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointsOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "city")
                        .WithMany("pointsofinterest")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("pointsofinterest");
                });
#pragma warning restore 612, 618
        }
    }
}