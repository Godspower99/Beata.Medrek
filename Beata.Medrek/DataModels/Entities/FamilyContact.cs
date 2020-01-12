using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek
{
    public class FamilyContact
    {
        #region Columns

        /// <summary>
        /// ID For EF Tracking
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Reference TO Patient MedRekNO
        /// Note:Relationship properties Set Using Fluent API
        /// </summary>
        [Required]
        public string MedRekNO { get; set; }

        /// <summary>
        /// Next Of Kin First Name
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        /// <summary>
        /// Next of Kin Last Name
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        /// <summary>
        /// Next of Kin Middle Name
        /// Note:Nullable
        /// </summary>
        [MaxLength(25)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Next of Kin Phone Number
        /// Note:Nullable
        /// </summary>
        [MaxLength(15)]
        public string Phone { get; set; }

        #endregion

        
        #region Relationship Endpoints

        /// <summary>
        /// Patient Owning This Entity Object
        /// </summary>
        public Patient Patient { get; set; }

        #endregion
    }
}
