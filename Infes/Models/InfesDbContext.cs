using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public class InfesDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<District> Districts { get; set; }
        private IConfiguration _configuration { get; }
        public InfesDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InfestationDbConnectionNew"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "US", Population = 328200000, SickCount = 17860634, DeadCount = 317729, RecoveredCount = 16800450, Vaccine = false },
                new Country { Id = 2, Name = "India", Population = 1353150536, SickCount = 10055560, DeadCount = 145810, RecoveredCount = 9606111, Vaccine = false },
                new Country { Id = 3, Name = "Brazil", Population = 209500000, SickCount = 7238600, DeadCount = 186764, RecoveredCount = 6409986, Vaccine = false });

            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, Name = "Ohio", Population = 1000000, SickCount = 1590, DeadCount = 100, RecoveredCount = 5000, Vaccine = false, CountryId = 1 },
                new District { Id = 2, Name = "Delhi", Population = 9000000, SickCount = 6000, DeadCount = 200, RecoveredCount = 4000, Vaccine = false, CountryId = 2 },
                new District { Id = 3, Name = "New York", Population = 13000000, SickCount = 7900, DeadCount = 300, RecoveredCount = 4500, Vaccine = false, CountryId = 1 },
                new District { Id = 4, Name = "Rio", Population = 8000000, SickCount = 3600, DeadCount = 400, RecoveredCount = 8000, Vaccine = false, CountryId = 3 },
                new District { Id = 5, Name = "Washington", Population = 700000, SickCount = 900, DeadCount = 70, RecoveredCount = 1700, Vaccine = false, CountryId = 1 },
                new District { Id = 6, Name = "Mumbai", Population = 15000000, SickCount = 8400, DeadCount = 190, RecoveredCount = 7000, Vaccine = false, CountryId = 2 });

            modelBuilder.Entity<Human>().HasData(
                new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1, DistrictId = 1 },
                new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1, DistrictId = 6 },
                new Human { Id = 5, FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", CountryId = 3, DistrictId = 4 },
                new Human { Id = 6, FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", CountryId = 3, DistrictId = 4 },
                new Human { Id = 7, FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", CountryId = 3, DistrictId = 4 },
                new Human { Id = 8, FirstName = "Petr", LastName = "Ilich", Age = 53, IsSick = true, Gender = "Male", CountryId = 2, DistrictId = 2 },
                new Human { Id = 9, FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", CountryId = 1, DistrictId = 3 });
        }
    }
}
