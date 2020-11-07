using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Repository.Context
{
    public class PersonDbContext : DbContext, IUnitOfWork
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }
        public PersonDbContext()
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Relation>()
            .Property(f => f.ID)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Relation>()
                .HasKey(e => new { e.PersonFromID, e.PersonToID });

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.PersonFrom)
                .WithMany()
                .HasForeignKey(e => e.PersonFromID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.PersonTo)
                .WithMany(e => e.RelativeTo)
                .HasForeignKey(e => e.PersonToID);

            //modelBuilder.Entity<Person>()
            //    .HasIndex(u => u.PersonalNumber)
            //    .IsUnique();


            //Seed DB
            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    ID = 1,
                    Name = "Zura",
                    Surname = "Samkharadze",
                    BirthDate = new DateTime(1996, 6, 28),
                    Gender = GenderType.Male,
                    PersonalNumber = "01008048579"
                },
                new Person()
                {
                    ID = 2,
                    Name = "Maiko",
                    Surname = "Samkharadze",
                    BirthDate = new DateTime(1998, 9, 14),
                    Gender = GenderType.Female,
                    PersonalNumber = "01008048580"
                },
                new Person()
                {
                    ID = 3,
                    Name = "Alex",
                    Surname = "Dvali",
                    BirthDate = new DateTime(1996, 2, 8),
                    Gender = GenderType.Male,
                    PersonalNumber = "91008048579"
                },
                new Person()
                {
                    ID = 4,
                    Name = "Zura",
                    Surname = "Esebua",
                    BirthDate = new DateTime(1990, 1, 18),
                    Gender = GenderType.Male,
                    PersonalNumber = "81008048579"
                });

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber()
                {
                    ID = 1,
                    Number = "599473377",
                    PersonID = 1,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 2,
                    Number = "0322458965",
                    PersonID = 1,
                    phoneNumberType = PhoneNumberType.Home
                },
                new PhoneNumber()
                {
                    ID = 3,
                    Number = "599478523",
                    PersonID = 2,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 4,
                    Number = "555555444",
                    PersonID = 3,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 5,
                    Number = "599473377",
                    PersonID = 4,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 6,
                    Number = "59999957",
                    PersonID = 4,
                    phoneNumberType = PhoneNumberType.Office
                });


            modelBuilder.Entity<Relation>().HasData(
                new Relation()
                {
                    ID = 1,
                    PersonFromID = 1,
                    PersonToID = 2,
                    RelationType = RelationType.Colleague
                },
                new Relation()
                {
                    ID = 2,
                    PersonFromID = 1,
                    PersonToID = 3,
                    RelationType = RelationType.Colleague
                },
                new Relation()
                {
                    ID = 3,
                    PersonFromID = 1,
                    PersonToID = 4,
                    RelationType = RelationType.Other
                },
                new Relation()
                {
                    ID = 4,
                    PersonFromID = 2,
                    PersonToID = 4,
                    RelationType = RelationType.Familiar
                },
                new Relation()
                {
                    ID = 5,
                    PersonFromID = 2,
                    PersonToID = 3,
                    RelationType = RelationType.Other
                },
                new Relation()
                {
                    ID = 6,
                    PersonFromID = 3,
                    PersonToID = 4,
                    RelationType = RelationType.Colleague
                });
        }

        public static readonly ILoggerFactory ConsoleLoggerFactory
      = LoggerFactory.Create(builder =>
      {
          builder
           .AddFilter((category, level) =>
               category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information)
           .AddConsole();
      });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(ConsoleLoggerFactory)
            .EnableSensitiveDataLogging();
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
