
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Beata.Medrek
{
    ///<Summary>
    /// Register New Client Prompt ViewModel
    /// Data Collected here will be transferred to Main DataBase
    ///<Summary>
    public class RegisterUserViewModel:BaseViewModel
    {
        #region Private Fields

        #endregion

        public Patient Patient { get; set; }

///#region Public Properties

        ///// <summary>
        ///// Patients List OF Family Contacts
        ///// </summary>
        //public List<FamilyContact> FamilyContacts { set ; get; }

        ///// <summary>
        ///// Patients Notes
        ///// </summary>
        //public List<PatientsNotes> Notes { set; get; }

        //#endregion

        #region ListItem Source

        /// <summary>
        /// Patient Gender List
        /// </summary>
        public List<string> GenderList =>new List<string>(){"--Select--","Male","Female",};

        /// <summary>
        /// Patient Marital Status List
        /// </summary>
        public List<string> MaritalStatusList => new List<string>()
        {
            "--Select--",
            "Single",
            "Married",
            "Widowed",
            "Single Parent",
            "Separated",
            "Divorced",
        };


        #endregion

        #region Constructors

        ///<Summary>
        /// Default Constructor for <see="RegisterUserViewModel"/>
        ///<Summary>
        public RegisterUserViewModel()
        {
            Patient = new Patient();
        }

        #endregion

    }
}
