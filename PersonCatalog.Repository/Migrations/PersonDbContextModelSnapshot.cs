﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonCatalog.Repository.Context;

namespace PersonCatalog.Repository.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("PersonalNumber")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("phoneNumberType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relations", b =>
                {
                    b.Property<int>("FromID")
                        .HasColumnType("int");

                    b.Property<int>("ToID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.HasKey("FromID", "ToID");

                    b.HasIndex("PersonID");

                    b.HasIndex("ToID");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", null)
                        .WithMany("Phones")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relations", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonFrom")
                        .WithMany()
                        .HasForeignKey("FromID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonCatalog.Domain.Domains.Person", null)
                        .WithMany("RelatedTo")
                        .HasForeignKey("PersonID");

                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonTo")
                        .WithMany("RelatedFrom")
                        .HasForeignKey("ToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}