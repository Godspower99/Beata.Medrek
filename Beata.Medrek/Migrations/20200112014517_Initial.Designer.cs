﻿// <auto-generated />
using System;
using Beata.Medrek;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beata.Medrek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200112014517_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beata.Medrek.FamilyContact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("MedRekNO")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.HasIndex("MedRekNO");

                    b.ToTable("PatientFamilyContacts");
                });

            modelBuilder.Entity("Beata.Medrek.Patient", b =>
                {
                    b.Property<string>("MedRekNO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MedRekNO");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Beata.Medrek.PatientAddress", b =>
                {
                    b.Property<string>("MedRekNO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimaryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SecondaryAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MedRekNO");

                    b.ToTable("PatientsAddresses");
                });

            modelBuilder.Entity("Beata.Medrek.PatientOriginOfBirth", b =>
                {
                    b.Property<string>("MedRekNO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LGA")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("MedRekNO");

                    b.ToTable("PatientOriginOfBirths");
                });

            modelBuilder.Entity("Beata.Medrek.PatientPhone", b =>
                {
                    b.Property<string>("MedRekNO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrimaryPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SecondaryPhone")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("MedRekNO");

                    b.ToTable("PatientPhones");
                });

            modelBuilder.Entity("Beata.Medrek.PatientsNotes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedRekNO")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StaffUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("MedRekNO");

                    b.HasIndex("StaffUsername");

                    b.ToTable("PatientsNotes");
                });

            modelBuilder.Entity("Beata.Medrek.Staff", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Middle")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PrimaryPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SecondaryPhone")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("UserName");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Beata.Medrek.FamilyContact", b =>
                {
                    b.HasOne("Beata.Medrek.Patient", "Patient")
                        .WithMany("FamilyContacts")
                        .HasForeignKey("MedRekNO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Beata.Medrek.PatientAddress", b =>
                {
                    b.HasOne("Beata.Medrek.Patient", "Patient")
                        .WithOne("Address")
                        .HasForeignKey("Beata.Medrek.PatientAddress", "MedRekNO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Beata.Medrek.PatientOriginOfBirth", b =>
                {
                    b.HasOne("Beata.Medrek.Patient", "Patient")
                        .WithOne("OriginOfBirth")
                        .HasForeignKey("Beata.Medrek.PatientOriginOfBirth", "MedRekNO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Beata.Medrek.PatientPhone", b =>
                {
                    b.HasOne("Beata.Medrek.Patient", "Patient")
                        .WithOne("Phone")
                        .HasForeignKey("Beata.Medrek.PatientPhone", "MedRekNO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Beata.Medrek.PatientsNotes", b =>
                {
                    b.HasOne("Beata.Medrek.Patient", "Patient")
                        .WithMany("Notes")
                        .HasForeignKey("MedRekNO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Beata.Medrek.Staff", "Staff")
                        .WithMany("Notes")
                        .HasForeignKey("StaffUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
