using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.Data
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region Country-State-City Join Class Config

            modelBuilder.Entity<Country>()
                .HasKey(dt => dt.CntyId);

            modelBuilder.Entity<State>()
                .HasKey(dt => dt.StateId);

            modelBuilder.Entity<City>()
                .HasKey(dt => dt.CityId);

            modelBuilder.Entity<State>()
                    .HasOne(dtk => dtk.Countries)
                    .WithMany(dt => dt.States)
                    .HasForeignKey(dtk => dtk.CountryId)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                    .HasOne(dtk => dtk.states)
                    .WithMany(dt => dt.Cities)
                    .HasForeignKey(e => e.StateId)
                    .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Country>().HasData(
                new Country() { CntyId = 1, CntyName = "Sweden" },
                new Country() { CntyId = 2, CntyName = "France" },
                new Country() { CntyId = 3, CntyName = "Italy" },
                new Country() { CntyId = 4, CntyName = "Germany" }
                );

            modelBuilder.Entity<State>().HasData(
                new State() { StateId = 1, StateName = "Kronoberg", CountryId = 1 },
                new State() { StateId = 2, StateName = "Skåne", CountryId = 1 },
                new State() { StateId = 3, StateName = "Uppsala", CountryId = 1 },
                new State() { StateId = 4, StateName = "Gäveborg", CountryId = 1 },
                new State() { StateId = 5, StateName = "Stockholm", CountryId = 1 },
                new State() { StateId = 6, StateName = "Gotland", CountryId = 1 },
                new State() { StateId = 7, StateName = "Berlin", CountryId = 3 },
                new State() { StateId = 8, StateName = "Bavaria", CountryId = 3 },
                new State() { StateId = 9, StateName = "Hamburg", CountryId = 3 }
                );

            modelBuilder.Entity<City>().HasData(
                new City() { CityId = 1, CityName = "Stockholm", StateId = 5 },
                new City() { CityId = 2, CityName = "Helsingborg", StateId = 2 },
                new City() { CityId = 3, CityName = "Växjö", StateId = 1 },
                new City() { CityId = 4, CityName = "Gävle", StateId = 4 },
                new City() { CityId = 5, CityName = "Visby", StateId = 6 },
                new City() { CityId = 6, CityName = "Berlin", StateId = 7 },
                new City() { CityId = 7, CityName = "Hamburg", StateId = 9 },
                new City() { CityId = 8, CityName = "Munich", StateId = 8 }
                );


            #endregion Country-State-City Join Class Config

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> State { get; set; }
    }
}
