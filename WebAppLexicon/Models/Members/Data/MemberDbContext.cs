using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Identity;

namespace WebAppLexicon.Models.Members.Data
{
    public class MemberDbContext : IdentityDbContext<IdentityUser>
//    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region Skills-Jobs Join Class Config

            modelBuilder.Entity<Skills>()
                .HasKey(dt =>
                new
                {
                    dt.MemberId,
                    dt.SkillId
                });


            modelBuilder.Entity<Skills>()
                .HasOne(dt => dt.SkillCat)
                .WithMany(d => d.Skills)
                .HasForeignKey(dt => dt.SkillId);

            modelBuilder.Entity<Skills>()
                .HasOne(ms => ms.Xmembers)
                .WithMany(s => s.SkillSet)
                .HasForeignKey(ms => ms.MemberId);
                

            modelBuilder.Entity<Jobs>()
                .HasKey(dt => dt.JobId);

            modelBuilder.Entity<SkillCats>().HasData(
                new SkillCats() { SkillId = 1, Categories = "Cleaning" },
                new SkillCats() { SkillId = 2, Categories = "Moving" },
                new SkillCats() { SkillId = 3, Categories = "Carpentry" },
                new SkillCats() { SkillId = 4, Categories = "Car washing" },
                new SkillCats() { SkillId = 5, Categories = "Pets Care" },
                new SkillCats() { SkillId = 6, Categories = "Baby Sitting" },
                new SkillCats() { SkillId = 7, Categories = "Story telling" },
                new SkillCats() { SkillId = 8, Categories = "Lundary" },
                new SkillCats() { SkillId = 9, Categories = "Simple Cooking" },
                new SkillCats() { SkillId = 10, Categories = "Baking" },
                new SkillCats() { SkillId = 11, Categories = "House Party Decoration" },
                new SkillCats() { SkillId = 12, Categories = "Magic Show for Kids" },
                new SkillCats() { SkillId = 13, Categories = "Panio" },
                new SkillCats() { SkillId = 14, Categories = "Teach Panio" },
                new SkillCats() { SkillId = 999, Categories = "Others" }

                );

            modelBuilder.Entity<Skills>().HasData(
                new Skills() { ID=1, SkillId=1,MemberId=9,SkillLevel=2,SkillYears=2},
                new Skills() { ID=2, SkillId =2,MemberId=3,SkillLevel=3,SkillYears=1},
                new Skills() { ID=3, SkillId=3,MemberId=13,SkillLevel=1,SkillYears=7},
                new Skills() { ID=4, SkillId=4,MemberId=13,SkillLevel=3,SkillYears=10},
                new Skills() { ID=5, SkillId=5,MemberId=5,SkillLevel=1,SkillYears=8},
                new Skills() { ID = 6, SkillId =6,MemberId=11,SkillLevel=3,SkillYears=9},
                new Skills() { ID = 7, SkillId =2,MemberId=7,SkillLevel=3,SkillYears=4},
                new Skills() { ID = 8, SkillId =8,MemberId=1,SkillLevel=1,SkillYears=4},
                new Skills() { ID = 9, SkillId =3,MemberId=6,SkillLevel=2,SkillYears=2},
                new Skills() { ID = 10, SkillId =10,MemberId=7,SkillLevel=2,SkillYears=2}
                );

            #endregion Country-State-City Join Class Config

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
                    .HasForeignKey(dtk => dtk.CntyId);

            modelBuilder.Entity<City>()
                    .HasOne(dtk => dtk.States)
                    .WithMany(dt => dt.Cities)
                    .HasForeignKey(e => e.StateId);

            modelBuilder.Entity<Members>()
                .HasKey(dt => dt.MemberId);

            modelBuilder.Entity<City>().HasData(
                new City() { CityId = 1, CityName = "Stockholm", StateId = 5 },
                new City() { CityId = 2, CityName = "Helsingborg", StateId = 2 },
                new City() { CityId = 3, CityName = "Växjö", StateId = 1 },
                new City() { CityId = 4, CityName = "Gävle", StateId = 4 },
                new City() { CityId = 5, CityName = "Visby", StateId = 6 },
                new City() { CityId = 6, CityName = "Berlin", StateId = 7 },
                new City() { CityId = 7, CityName = "Hamburg", StateId = 9 },
                new City() { CityId = 9, CityName = "Lund", StateId = 2 },
                new City() { CityId = 8, CityName = "Munich", StateId = 8 },
                new City() { CityId = 10, CityName = "Rome", StateId = 10 },
                new City() { CityId = 11, CityName = "Paris", StateId = 11 }
                );

            modelBuilder.Entity<State>().HasData(
                new State() { StateId = 1, StateName = "Kronoberg", CntyId = 1 },
                new State() { StateId = 2, StateName = "Skåne", CntyId = 1 },
                new State() { StateId = 3, StateName = "Uppsala", CntyId = 1 },
                new State() { StateId = 4, StateName = "Gäveborg", CntyId = 1 },
                new State() { StateId = 5, StateName = "Stockholm", CntyId = 1 },
                new State() { StateId = 6, StateName = "Gotland", CntyId = 1 },
                new State() { StateId = 7, StateName = "Berlin", CntyId = 4 },
                new State() { StateId = 8, StateName = "Bavaria", CntyId = 4 },
                new State() { StateId = 9, StateName = "Hamburg", CntyId = 4 },
                new State() { StateId = 10, StateName = "Lazio", CntyId = 3 },
                new State() { StateId = 11, StateName = "Île‑de‑France", CntyId = 2 }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country() { CntyId = 1, CntyName = "Sweden" },
                new Country() { CntyId = 2, CntyName = "France" },
                new Country() { CntyId = 3, CntyName = "Italy" },
                new Country() { CntyId = 4, CntyName = "Germany" }
                );

            modelBuilder.Entity<Members>().HasData(
                new Members() { MemberId = 1, FirstName = "Giustina", LastName = "Gurnay", Phone = "108-553-0832", Gender = "Genderfluid", Age = 30, Nationality = "Panamanian", Email = "ggurnay0@opera.com", CntyId=1, StateId=1, CtyId=3 },
                new Members() { MemberId = 2, FirstName = "Danita", LastName = "Kissick", Phone = "102-688-4545", Gender = "Female", Age = 76, Nationality = "Iroquois", Email = "dkissick1@clickbank.net", CntyId = 4, StateId = 8, CtyId = 7 },
                new Members() { MemberId = 3, FirstName = "Creigh", LastName = "Noice", Phone = "934-181-5000", Gender = "Male", Age = 35, Nationality = "Shoshone", Email = "cnoice2@wisc.edu", CntyId = 1, StateId = 1, CtyId = 3 },
                new Members() { MemberId = 4, FirstName = "Denis", LastName = "Hourihane", Phone = "260-684-7945", Gender = "Male", Age = 67, Nationality = "American Indian and Alaska Native (AIAN)", Email = "dhourihane3@toplist.cz", CntyId = 3, StateId = 10, CtyId = 10 },
                new Members() { MemberId = 5, FirstName = "Ariel", LastName = "Nattriss", Phone = "662-951-7611", Gender = "Male", Age = 62, Nationality = "Chickasaw", Email = "anattriss4@baidu.com", CntyId = 1, StateId = 2, CtyId = 2 },
                new Members() { MemberId = 6, FirstName = "Tommie", LastName = "Velte", Phone = "474-732-2163", Gender = "Male", Age = 35, Nationality = "Filipino", Email = "tvelte5@nps.gov", CntyId = 4, StateId = 8, CtyId = 7 },
                new Members() { MemberId = 7, FirstName = "Dennison", LastName = "Gonzales", Phone = "706-580-3696", Gender = "Male", Age = 40, Nationality = "Puerto Rican", Email = "dgonzales6@yelp.com", CntyId = 1, StateId = 1, CtyId = 3 },
                new Members() { MemberId = 8, FirstName = "Tynan", LastName = "Morphet", Phone = "298-108-6587", Gender = "Non-binary", Age = 56, Nationality = "White", Email = "tmorphet7@wix.com", CntyId = 3, StateId = 10, CtyId = 10 },
                new Members() { MemberId = 9, FirstName = "Mischa", LastName = "Foulstone", Phone = "853-913-7659", Gender = "Male", Age = 33, Nationality = "Menominee", Email = "mfoulstone8@narod.ru", CntyId = 2, StateId = 11, CtyId = 11 },
                new Members() { MemberId = 10, FirstName = "Lisa", LastName = "Olczak", Phone = "225-320-9656", Gender = "Female", Age = 49, Nationality = "Vietnamese", Email = "lolczak9@spiegel.de", CntyId = 1, StateId = 2, CtyId = 9 },
                new Members() { MemberId = 11, FirstName = "Rancell", LastName = "Gennings", Phone = "594-235-3927", Gender = "Genderfluid", Age = 38, Nationality = "Tlingit-Haida", Email = "rgenningsa@bloglines.com", CntyId = 2, StateId = 11, CtyId = 11 },
                new Members() { MemberId = 12, FirstName = "Kingsly", LastName = "Mongan", Phone = "805-257-2819", Gender = "Male", Age = 18, Nationality = "Yaqui", Email = "kmonganb@1und1.de", CntyId = 1, StateId = 2, CtyId = 2 },
                new Members() { MemberId = 13, FirstName = "Sayer", LastName = "Ortells", Phone = "201-214-9764", Gender = "Male", Age = 55, Nationality = "Honduran", Email = "sortellsc@yelp.com", CntyId = 2, StateId = 11, CtyId = 11 },
                new Members() { MemberId = 14, FirstName = "Abbie", LastName = "Knotte", Phone = "870-289-5196", Gender = "Male", Age = 32, Nationality = "Argentinian", Email = "aknotted@apache.org", CntyId = 4, StateId = 9, CtyId = 7 },
                new Members() { MemberId = 15, FirstName = "Vilma", LastName = "Puttrell", Phone = "176-399-0215", Gender = "Polygender", Age = 90, Nationality = "Laotian", Email = "vputtrelle@nytimes.com", CntyId = 4, StateId = 9, CtyId = 7 },
                new Members() { MemberId = 16, FirstName = "Amber", LastName = "Buffery", Phone = "716-926-5332", Gender = "Female", Age = 71, Nationality = "Chilean", Email = "abufferyf@jalbum.net", CntyId = 1, StateId = 1, CtyId = 3 },
                new Members() { MemberId = 17, FirstName = "Wiatt", LastName = "Collet", Phone = "369-361-2111", Gender = "Male", Age = 64, Nationality = "Chilean", Email = "wcolletg@a8.net", CntyId = 1, StateId = 4, CtyId = 4 },
                new Members() { MemberId = 18, FirstName = "Cacilia", LastName = "Gilstin", Phone = "582-143-5937", Gender = "Female", Age = 18, Nationality = "Cree", Email = "cgilstinh@ucla.edu", CntyId = 1, StateId = 2, CtyId = 9 },
                new Members() { MemberId = 19, FirstName = "Libbie", LastName = "Zecchii", Phone = "529-137-4269", Gender = "Female", Age = 53, Nationality = "Paiute", Email = "lzecchiii@domainmarket.com", CntyId = 4, StateId = 9, CtyId = 7 },
                new Members() { MemberId = 20, FirstName = "Cecilia", LastName = "Lesslie", Phone = "358-511-7422", Gender = "Female", Age = 46, Nationality = "Tongan", Email = "clessliej@boston.com", CntyId = 3, StateId = 10, CtyId = 10 }
                );

            #endregion Country-State-City Join Class Config


            #region Identity User Seeding


            string superRoleId = Guid.NewGuid().ToString();
            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData
            (new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = superRoleId,
                ConcurrencyStamp = superRoleId
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId
            });

            string superAdminId = Guid.NewGuid().ToString();
            string adminId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<AppUser>().HasData
            (new AppUser
            {
                Id = superAdminId,
                UserName = "SuperAdmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "P@ssW0rd"),
                FirstName = "Louis",
                LastName = "Lim",
                EmailConfirmed = true,
                //DateOfBirth = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                MemberId = 9999,
                UserRolesId = superRoleId
            },

            new AppUser
            {
                Id = adminId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Asdf!234"),
                FirstName = "Vicient",
                LastName = "Hook",
                EmailConfirmed = true,
                //DateOfBirth = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                MemberId = 9998,
                UserRolesId = adminRoleId
            },
            new AppUser
            {
                Id = userId,
                UserName = "User1",
                NormalizedUserName = "USER1",
                Email = "user1@gmail.com",
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "NeWY@8rs"),
                FirstName = "Vicient",
                LastName = "Kent",
                EmailConfirmed = true,
                //DateOfBirth = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserRolesId = userRoleId
            });

            //set user role to admin

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = superRoleId,
                UserId = superAdminId
            },
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            },
            new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId
            }
        );
            #endregion
        }
        public DbSet<Members> Members { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SkillCats> SkillCats { get; set; }
        public DbSet<Jobs> Jobs { get; set; }

    }
}
