
using System;

namespace Beata.Medrek.Standard
{
    ///<Summary>
    /// Data Model of Patients
    ///<Summary>
    public class PatientModel
    {
        /// <summary>
        /// Patients First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Patients Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Patients Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Patients Medrek Number
        /// NOTE: This will be AUTO-GENERATED
        /// </summary>
        public string MedrekNumber { get; set; }

        /// <summary>
        /// Patients Date of Birth
        /// </summary>
        public DateTimeOffset DateofBirth { get; set; }

        /// <summary>
        /// Patients Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Patients Marital Status
        /// </summary>
        public string MaritalStatus{ get; set; }

        /// <summary>
        /// Patients First Address
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Patients Second Address
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Patients City or Town
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Patients Zip Code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Patients State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Patients Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Patients First Phone Number
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Patients Second Phone Number
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Patients Next of Kin
        /// </summary>
        public string NextOfKin { get; set; }

        /// <summary>
        /// Patients Next of Kin Phone Number
        /// </summary>
        public string NextofKinPhone { get; set; }

        /// <summary>
        /// Patients Extra Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Patients Picture Location
        /// </summary>
        public string PictureSource { get; set; }
    }
}
