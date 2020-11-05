using Microsoft.EntityFrameworkCore;
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
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Relations>()
                .HasKey(e => new { e.FromID, e.ToID });

            modelBuilder.Entity<Relations>()
                .HasOne(e => e.PersonFrom)
                .WithMany()
                .HasForeignKey(e => e.FromID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relations>()
                .HasOne(e => e.PersonTo)
                .WithMany(e => e.RelatedFrom)
                .HasForeignKey(e => e.ToID);

            modelBuilder.Entity<Person>()
                .HasIndex(u => u.PersonalNumber)
                .IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
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
