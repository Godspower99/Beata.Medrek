using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek.Core
{
   public class PatientsNotes
    {
        #region Columns

        /// <summary>
        /// EF Tracker
        /// </summary>
        public int ID { get; set; }

        [Required]
        public string MedRekNO { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(25)]
        public string StaffUsername { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        #endregion

        
        #region Relationship Endpoints

        public Patient Patient { get; set; }

        public  Staff Staff { get; set; }
        #endregion
    }
}
