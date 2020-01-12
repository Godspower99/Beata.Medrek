using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek.Core
{
  public class PatientAddress
    {
        #region Columns

        /// <summary>
        /// Referencing Patient MedRekNO
        /// Note:Relationship properties set using Fluent API
        /// </summary>
        [Required]
        [Key]
        public string MedRekNO { get; set; }

        /// <summary>
        /// Patient Main Address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string PrimaryAddress { get; set; }

        /// <summary>
        /// Patient Secondary Address
        /// Note:Nullable
        /// </summary>
        [MaxLength(100)]
        public string SecondaryAddress { get; set; }

        #endregion

        #region RelationShip Endpoints

        /// <summary>
        /// Patient Owing this Entity Object
        /// </summary>
        public Patient Patient { get; set; }
        #endregion
    }
}
