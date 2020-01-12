
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Beata.Medrek.Core
{
    ///<Summary>
    /// Register New Client Prompt ViewModel
    /// Data Collected here will be transferred to Main DataBase
    ///<Summary>
    public class RegisterUserViewModel:BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Instance of patient Model for registering new user
        /// </summary>
        private Patient _newPatients;
        #endregion

        #region Public Properties

        /// <summary>
        /// Patients First Name
        /// </summary>
        public string FirstName{set{_newPatients.FirstName = value;}get{return _newPatients.FirstName;}}

        /// <summary>
        /// Patients Last Name
        /// </summary>
        public string LastName { set { _newPatients.LastName = value; } get { return _newPatients.LastName; }}

        /// <summary>
        /// Patients Middle Name
        /// </summary>
        public string MiddleName { set { _newPatients.MiddleName = value; } get { return _newPatients.MiddleName; } }

        /// <summary>
        /// Patients Address
        /// </summary>
        public PatientAddress Address { get; set; }

        /// <summary>
        /// Patients Origin Of Birth
        /// </summary>
        public PatientOriginOfBirth OriginOfBirth { get; set; } 
       
        /// <summary>
        /// Patients DateofBirth
        /// </summary>
        public DateTime DateofBirth { set { _newPatients.DateOfBirth = value; } get { return _newPatients.DateOfBirth; } }

        /// <summary>
        /// Patients Gender
        /// </summary>
        public string Gender { set { _newPatients.Gender = value; } get { return _newPatients.Gender; } }

        /// <summary>
        /// Patients MaritalStatus
        /// </summary>
        public string MaritalStatus { set { _newPatients.MaritalStatus = value; } get { return _newPatients.MaritalStatus; } }

        /// <summary>
        /// Patients MedrekNumber
        /// </summary>
        public string MedRekNumber { set { _newPatients.MedRekNO = value; } get { return _newPatients.MedRekNO; } }

        /// <summary>
        /// Patients List OF Family Contacts
        /// </summary>
        public List<FamilyContact> FamilyContacts { set ; get; }

        /// <summary>
        /// Patients Notes
        /// </summary>
        public List<PatientsNotes> Notes { set; get; }

        /// <summary>
        /// Patients Phone Contact
        /// </summary>
        public PatientPhone Phone { get; set; }

        #endregion

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
            _newPatients = new Patient();

            // Bind Commands TO Methods
            SaveCommand = new RelayCommand(Save);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Load Image Command
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// Clear image Command
        /// </summary>
        public ICommand ClearCommand { get; set; }

        /// <summary>
        /// Save Patient Command
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Cancel Registration Command
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Command Methods

        /// <summary>
        /// Save New User Command Method
        /// </summary>
        private void Save()
        {
       
        }

        /// <summary>
        /// Cance New User Registration Command Method
        /// </summary>
        private void Cancel()
        {

        }

        /// <summary>
        /// Load New User Picture Command Method
        /// </summary>
        private void Load()
        {

        }

        /// <summary>
        /// Clear New User Picture Command Method
        /// </summary>
        private void Clear()
        {

        }

        #endregion
    }
}
