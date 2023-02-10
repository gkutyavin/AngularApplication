﻿// <auto-generated />
using BackendApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendApi.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Country", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Country 1"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Country 2"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Country 3"
                        });
                });

            modelBuilder.Entity("BackendApi.Models.Province", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Province", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CountryID = 1,
                            Name = "Province 1.1"
                        },
                        new
                        {
                            ID = 2,
                            CountryID = 2,
                            Name = "Province 2.1"
                        },
                        new
                        {
                            ID = 3,
                            CountryID = 2,
                            Name = "Province 2.2"
                        },
                        new
                        {
                            ID = 4,
                            CountryID = 2,
                            Name = "Province 2.3"
                        },
                        new
                        {
                            ID = 5,
                            CountryID = 3,
                            Name = "Province 3.1"
                        },
                        new
                        {
                            ID = 6,
                            CountryID = 3,
                            Name = "Province 3.2"
                        });
                });

            modelBuilder.Entity("BackendApi.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Agree")
                        .HasColumnType("bit");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BackendApi.Models.Province", b =>
                {
                    b.HasOne("BackendApi.Models.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BackendApi.Models.User", b =>
                {
                    b.HasOne("BackendApi.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BackendApi.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("BackendApi.Models.Country", b =>
                {
                    b.Navigation("Provinces");
                });
#pragma warning restore 612, 618
        }
    }
}