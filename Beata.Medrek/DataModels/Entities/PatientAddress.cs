using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beata.Medrek
{
   public class PatientAddress
    {

        #region Public Properties
        /// <summary>
        /// The Patient Medrek no
        /// </summary>
        [Key]
        public string MedRekNO { get; set; }

        /// <summary>
        /// The Patients Main Address
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string PrimaryAddress { get; set; }

        /// <summary>
        /// Second Address
        /// Optional
        /// </summary>
        [MaxLength(255)]
        public string SecondaryAddress { get; set; }

        /// <summary>
        /// Patient Address Zip Code
        /// </summary>
        [MaxLength(10)]
        public string ZipCode { get; set; }
        #endregion

        #region Relationship Endpoints

        /// <summary>
        /// The Patient Referring to this Address
        /// </summary>
        public Patient Patient { get; set; }
        #endregion
    }
}
