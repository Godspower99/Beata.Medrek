using Beata.Medrek.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Beata.Medrek.Core
{ 
  public class HospitalDatabase:DbContext
    {
        #region Private Members

        private DbContextOptionsBuilder _optionsBuilder;
        #endregion
        #region Public Properties And DbSet
        /// <summary>
        /// Registered Staffs Entity
        /// </summary>
        public DbSet<Staff> Staffs { get; set; }

        /// <summary>
        /// Registered Hospital Clients/Patients
        /// </summary>
        public DbSet<Patient> Patients { get; set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="options">DbContext options passed to base class</param>
        public HospitalDatabase(DbContextOptionsBuilder optionsBuilder) { _optionsBuilder = optionsBuilder;  }

        #endregion

        #region OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = _optionsBuilder;
        }
        #endregion


        #region Fluent API
        /// <summary>
        /// Fluent API Settings
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Staff Indexer Settings
            modelBuilder.Entity<Staff>()
                .HasIndex(p => p.UserName)
                .IsUnique();

            // Patient Primary Key [MedRekNO] Settings
            modelBuilder.Entity<Patient>()
                .Property(p => p.MedRekNO)
                .ValueGeneratedNever();

            // One-Many Relationship Between Patient And FamilyContact
            modelBuilder.Entity<FamilyContact>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.FamilyContacts)
                .HasForeignKey(r => r.MedRekNO)
                .HasPrincipalKey(pr => pr.MedRekNO);

            // One-One Relationship Between Patient And PatientAddress
            modelBuilder.Entity<PatientAddress>()
                .HasOne(p => p.Patient)
                .WithOne(p=>p.Address)
                .HasForeignKey<PatientAddress>(p=>p.MedRekNO);

            // One-One Relationship Between Patient And PatientOriginOfBirth
            modelBuilder.Entity<PatientOriginOfBirth>()
                .HasOne(p => p.Patient)
                .WithOne(p=>p.OriginOfBirth)
                .HasForeignKey<PatientOriginOfBirth>(p=>p.MedRekNO);

            // One-One Relationship Between Patient And PatientPhone
            modelBuilder.Entity<PatientPhone>()
                .HasOne(p => p.Patient)
                .WithOne(p=>p.Phone)
                .HasForeignKey<PatientPhone>(p=>p.MedRekNO);

            // One-Many Relationship Between Patient And PatientNotes
            modelBuilder.Entity<PatientsNotes>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Notes)
                .HasForeignKey(fk => fk.MedRekNO)
                .HasPrincipalKey(pk => pk.MedRekNO);

            // One-Many RelationShip Between Staff And PatientNotes
            modelBuilder.Entity<PatientsNotes>()
                .HasOne(p => p.Staff)
                .WithMany(p => p.Notes)
                .HasForeignKey(fk => fk.StaffUsername)
                .HasPrincipalKey(pk => pk.UserName);

        } 
        #endregion
    }
}
