using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek
{
    public class PatientPhone
    {
        #region Columns

        /// <summary>
        /// Referencing Patient MedRekNO
        /// </summary>
        [Required]
        [Key]
        public string MedRekNO { get; set; }

        /// <summary>
        /// Patient Main Phone Contact
        /// </summary>
        [Required]
        [MaxLength(15)]
        public string PrimaryPhone { get; set; }

        /// <summary>
        /// Patient Secondary Phone
        /// Note:Nullable
        /// </summary>
        [MaxLength(15)]
        public string SecondaryPhone { get; set; }

        /// <summary>
        /// Patient Email Address
        /// Note:Nullable
        /// </summary>
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        #endregion

        #region Relationship EndPoints

        /// <summary>
        /// Patient Owing This Entity Object
        /// </summary>
        public Patient Patient { get; set; }
        #endregion
    }
}
