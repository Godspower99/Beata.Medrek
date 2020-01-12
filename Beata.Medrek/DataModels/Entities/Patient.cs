using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek
{
 public class Patient
    {
        #region Patient Columns

        /// <summary>
        /// Patient MedrekNO
        /// Note:A Combination of First name Last And Last Three Numbers from Phone Number
        /// TODO IMPORTANT:::Create Server Side Algorithm for Auto Generating The Unique Number
        /// Note:Primary Key
        /// Note:At The Moment Auto Generated Is Turned Off Using Fluent API
        /// </summary>
        [Key]
        public string MedRekNO { get; set; }

        /// <summary>
        /// Patient First Name
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        /// <summary>
        /// Patient Middle Name
        /// Note:Nullable
        /// </summary>
        [MaxLength(25)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Patient Last Name
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        /// <summary>
        /// Patient Title if Available
        /// Note:Nullable
        /// </summary>
        [MaxLength(10)]
        public string Title { get; set; }

        /// <summary>
        /// Patient Date of Birth
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Patient Gender
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        /// <summary>
        /// Patient Marital Status 
        /// Note:Nullable 
        /// </summary>
        [MaxLength(25)]
        public string MaritalStatus { get; set; }

        /// <summary>
        /// Patient Measured Weight
        /// Note:Nullable
        /// </summary>
        public decimal Weight { get; set; }
       
        /// <summary>
        /// Patient Measured Height
        /// Note:Nullable
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Date and Time Of Patient Registration
        /// </summary>
        [Required]
        public DateTime RegistrationTime { get; set; }

        #endregion


        #region Relationship EndPoints

        /// <summary>
        /// Patient List Of Family Contacts
        /// Note:Relationship properties Set Using Fluent API
        /// </summary>
        public List<FamilyContact> FamilyContacts { get; set; }

        /// <summary>
        /// Patient Address
        /// Note:Relationship properties Set Using Fluent API
        /// </summary>
        public PatientAddress Address { get; set; }

        /// <summary>
        /// Patient Phone Contacts
        /// Note:Relationship properties Set using Fluent API
        /// </summary>
        public PatientPhone Phone { get; set; }

        /// <summary>
        /// List of Patients Notes Recorded
        /// Note:Relationship properties Set Using Fluent API
        /// </summary>
        public List<PatientsNotes> Notes { get; set; }

        /// <summary>
        /// Patient Origin Of Birth
        /// Note:Relationship properties Set using Fluent API
        /// </summary>
        public PatientOriginOfBirth OriginOfBirth { get; set; }

        #endregion
    }
}
