using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beata.Medrek
{
    public class Staff
    {
        #region Columns

         /// <summary>
        /// Staff UserName For Login
        /// Note:Auto Generated Value Turned Off with Fluent API
        /// Note:Set As Index For Staff Table
        /// </summary>
        [MaxLength(25)]
        [Key]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        /// <summary>
        /// Staff Admin Status To Determine Database Roles
        /// </summary>
        [Required]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Staff First Name 
        /// </summary>
        [MaxLength(25)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Staff Middle Name
        /// Note:NUllable
        /// </summary>
        [MaxLength(25)]
        public string Middle { get; set; }

        /// <summary>
        /// Staff Last Name
        /// </summary>
        [MaxLength(25)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Staff Title if Available
        /// Note:Nullable
        /// </summary>
        [MaxLength(10)]
        public string Title { get; set; }

        /// <summary>
        /// Staff Working Position in Hospital
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Position { get; set; }

        /// <summary>
        /// Staff Main Phone Contact
        /// </summary>
        [MaxLength(15)]
        [Required]
        public string PrimaryPhone { get; set; }

        /// <summary>
        /// Staff Secondary Phone Contact
        /// Note:NUllable
        /// </summary>
        [MaxLength(15)]
        public string SecondaryPhone { get; set; }

        /// <summary>
        /// Staff Image or Passport
        /// TODO IMPORTANT::Limit Image Size
        /// Note:Nullable
        /// </summary>
        public byte[] Image { get; set; }

        #endregion

        #region Relationship Endpoints

        /// <summary>
        /// List of Notes Taken By Staff
        /// Note:Relationship properties set using Fluent API
        /// </summary>
        public List<PatientsNotes> Notes { get; set; }
        #endregion
    }
}
