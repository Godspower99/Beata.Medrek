
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;


namespace Beata.Medrek
{ 
  public class ApplicationDbContext:DbContext
    { 
        #region Public Properties And DbSet
        /// <summary>
        /// Registered Staffs Entity
        /// </summary>
        public DbSet<Staff> Staffs { get; set; }

        /// <summary>
        /// Registered Hospital Clients/Patients
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Registered Patients Notes
        /// </summary>
        public DbSet<PatientsNotes> PatientsNotes { get; set; }

        /// <summary>
        /// Registered Patient Phone
        /// </summary>
        public DbSet<PatientPhone> PatientPhones { get; set; }

        /// <summary>
        /// Registered Patients Origin Of Birth
        /// </summary>
        public DbSet<PatientOriginOfBirth> PatientOriginOfBirth { get; set; }
        
        /// <summary>
        /// Registered Patients Family Contacts
        /// </summary>
        public DbSet<FamilyContact> PatientFamilyContacts { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="options">DbContext options passed to base class</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

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

            // One-One Relationship Between Patient and PatientAddress
            modelBuilder.Entity<PatientAddress>()
                .HasOne(p => p.Patient)
                .WithOne(p => p.PatientAddress)
                .HasForeignKey<PatientAddress>(p => p.MedRekNO);

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
                .HasPrincipalKey(pk => pk.UserName)
                .OnDelete(DeleteBehavior.NoAction);

        }
        #endregion
        
    }

    /// <summary>
    /// Design Time DbContext Migration
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=OTIETE\\SQLEXPRESS;Database=ApplicationDbContext;Trusted_Connection=true;MultipleActiveResultSets=true;");
            return new ApplicationDbContext(options.Options);
        }
    }
}
