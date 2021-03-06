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

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(1996, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = (byte)1,
                            Name = "Zura",
                            PersonalNumber = "01008048579",
                            Surname = "Samkharadze"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = (byte)2,
                            Name = "Maiko",
                            PersonalNumber = "01008048580",
                            Surname = "Samkharadze"
                        },
                        new
                        {
                            ID = 3,
                            BirthDate = new DateTime(1996, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = (byte)1,
                            Name = "Alex",
                            PersonalNumber = "91008048579",
                            Surname = "Dvali"
                        },
                        new
                        {
                            ID = 4,
                            BirthDate = new DateTime(1990, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = (byte)1,
                            Name = "Zura",
                            PersonalNumber = "81008048579",
                            Surname = "Esebua"
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("phoneNumberType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Number = "599473377",
                            PersonID = 1,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 2,
                            Number = "0322458965",
                            PersonID = 1,
                            phoneNumberType = 3
                        },
                        new
                        {
                            ID = 3,
                            Number = "599478523",
                            PersonID = 2,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 4,
                            Number = "555555444",
                            PersonID = 3,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 5,
                            Number = "599473377",
                            PersonID = 4,
                            phoneNumberType = 1
                        },
                        new
                        {
                            ID = 6,
                            Number = "59999957",
                            PersonID = 4,
                            phoneNumberType = 2
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relation", b =>
                {
                    b.Property<int>("PersonFromID")
                        .HasColumnType("int");

                    b.Property<int>("PersonToID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.HasKey("PersonFromID", "PersonToID");

                    b.HasIndex("PersonID");

                    b.HasIndex("PersonToID");

                    b.ToTable("Relations");

                    b.HasData(
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 2,
                            ID = 1,
                            RelationType = 1
                        },
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 3,
                            ID = 2,
                            RelationType = 1
                        },
                        new
                        {
                            PersonFromID = 1,
                            PersonToID = 4,
                            ID = 3,
                            RelationType = 4
                        },
                        new
                        {
                            PersonFromID = 2,
                            PersonToID = 4,
                            ID = 4,
                            RelationType = 2
                        },
                        new
                        {
                            PersonFromID = 2,
                            PersonToID = 3,
                            ID = 5,
                            RelationType = 4
                        },
                        new
                        {
                            PersonFromID = 3,
                            PersonToID = 4,
                            ID = 6,
                            RelationType = 1
                        });
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.PhoneNumber", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonCatalog.Domain.Domains.Relation", b =>
                {
                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonFrom")
                        .WithMany()
                        .HasForeignKey("PersonFromID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonCatalog.Domain.Domains.Person", null)
                        .WithMany("RelativeFrom")
                        .HasForeignKey("PersonID");

                    b.HasOne("PersonCatalog.Domain.Domains.Person", "PersonTo")
                        .WithMany("RelativeTo")
                        .HasForeignKey("PersonToID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
