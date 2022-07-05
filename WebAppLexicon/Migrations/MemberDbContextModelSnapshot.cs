﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Migrations
{
    [DbContext(typeof(MemberDbContext))]
    partial class MemberDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppLexicon.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Stockholm",
                            StateId = 5
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Helsingborg",
                            StateId = 2
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Växjö",
                            StateId = 1
                        },
                        new
                        {
                            CityId = 4,
                            CityName = "Gävle",
                            StateId = 4
                        },
                        new
                        {
                            CityId = 5,
                            CityName = "Visby",
                            StateId = 6
                        },
                        new
                        {
                            CityId = 6,
                            CityName = "Berlin",
                            StateId = 7
                        },
                        new
                        {
                            CityId = 7,
                            CityName = "Hamburg",
                            StateId = 9
                        },
                        new
                        {
                            CityId = 8,
                            CityName = "Munich",
                            StateId = 8
                        });
                });

            modelBuilder.Entity("WebAppLexicon.Models.Country", b =>
                {
                    b.Property<int>("CntyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CntyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CntyId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CntyId = 1,
                            CntyName = "Sweden"
                        },
                        new
                        {
                            CntyId = 2,
                            CntyName = "France"
                        },
                        new
                        {
                            CntyId = 3,
                            CntyName = "Italy"
                        },
                        new
                        {
                            CntyId = 4,
                            CntyName = "Germany"
                        });
                });

            modelBuilder.Entity("WebAppLexicon.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("State");

                    b.HasData(
                        new
                        {
                            StateId = 1,
                            CountryId = 1,
                            StateName = "Kronoberg"
                        },
                        new
                        {
                            StateId = 2,
                            CountryId = 1,
                            StateName = "Skåne"
                        },
                        new
                        {
                            StateId = 3,
                            CountryId = 1,
                            StateName = "Uppsala"
                        },
                        new
                        {
                            StateId = 4,
                            CountryId = 1,
                            StateName = "Gäveborg"
                        },
                        new
                        {
                            StateId = 5,
                            CountryId = 1,
                            StateName = "Stockholm"
                        },
                        new
                        {
                            StateId = 6,
                            CountryId = 1,
                            StateName = "Gotland"
                        },
                        new
                        {
                            StateId = 7,
                            CountryId = 3,
                            StateName = "Berlin"
                        },
                        new
                        {
                            StateId = 8,
                            CountryId = 3,
                            StateName = "Bavaria"
                        },
                        new
                        {
                            StateId = 9,
                            CountryId = 3,
                            StateName = "Hamburg"
                        });
                });

            modelBuilder.Entity("WebAppLexicon.Models.City", b =>
                {
                    b.HasOne("WebAppLexicon.Models.State", "states")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAppLexicon.Models.State", b =>
                {
                    b.HasOne("WebAppLexicon.Models.Country", "Countries")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
