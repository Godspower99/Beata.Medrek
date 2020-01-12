using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek
{
  public class PatientOriginOfBirth
    {
        #region Columns

        /// <summary>
        /// Referencing Patient MedRekNO
        /// </summary>
        [Required]
        [Key]
        public string MedRekNO { get; set; }

        /// <summary>
        /// Patient Country of Origin
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string Country { get; set; }

        /// <summary>
        /// Patient State Of Birth
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string State { get; set; }

        /// <summary>
        /// Patient City Of Origin
        /// </summary>
        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        /// <summary>
        /// Patient Local Government Area
        /// Note:Nullable
        /// </summary>
        [MaxLength(30)]
        public string LGA { get; set; }

        #endregion

        #region Relationship Endpoints

        /// <summary>
        /// Patient Owing This Entity Object
        /// </summary>
        public Patient Patient { get; set; }
        #endregion
    }
}
