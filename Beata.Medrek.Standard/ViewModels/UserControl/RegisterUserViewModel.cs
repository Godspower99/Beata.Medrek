
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Beata.Medrek.Standard
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
        private PatientModel _newPatients;
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
        public string MIddleName { set { _newPatients.MiddleName = value; } get { return _newPatients.MiddleName; } }

        /// <summary>
        /// Patients AddressLine1
        /// </summary>
        public string AddressLine1 { set { _newPatients.AddressLine1 = value; } get { return _newPatients.AddressLine1; } }

        /// <summary>
        /// Patients AddressLine2
        /// </summary>
        public string AddressLine2 { set { _newPatients.AddressLine2 = value; } get { return _newPatients.AddressLine2; } }

        /// <summary>
        /// Patients City
        /// </summary>
        public string City { set { _newPatients.City = value; } get { return _newPatients.City; } }

        /// <summary>
        /// Patients Country
        /// </summary>
        public string Country { set { _newPatients.Country = value; } get { return _newPatients.Country; } }

        /// <summary>
        /// Patients DateofBirth
        /// </summary>
        public DateTimeOffset DateofBirth { set { _newPatients.DateofBirth = value; } get { return _newPatients.DateofBirth; } }

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
        public string MedrekNumber { set { _newPatients.MedrekNumber = value; } get { return _newPatients.MedrekNumber; } }

        /// <summary>
        /// Patients NextOfKin\
        /// </summary>
        public string NextOfKin { set { _newPatients.NextOfKin = value; } get { return _newPatients.NextOfKin; } }

        /// <summary>
        /// Patients NextofKinPhone
        /// </summary>
        public string NextofKinPhone { set { _newPatients.NextofKinPhone = value; } get { return _newPatients.NextofKinPhone; } }

        /// <summary>
        /// Patients Notes
        /// </summary>
        public string Notes { set { _newPatients.Notes = value; } get { return _newPatients.Notes; } }

        /// <summary>
        /// Patients Phone1
        /// </summary>
        public string Phone1 { set { _newPatients.Phone1 = value; } get { return _newPatients.Phone1; } }

        /// <summary>
        /// Patients Phone2
        /// </summary>
        public string Phone2 { set { _newPatients.Phone2 = value; } get { return _newPatients.Phone2; } }

        /// <summary>
        /// Patients PictureSource
        /// </summary>
        public string PictureSource { set { _newPatients.PictureSource = value; } get { return _newPatients.PictureSource; } }

        /// <summary>
        /// Patients State of origin
        /// </summary>
        public string State { set { _newPatients.State = value; } get { return _newPatients.State; } }

        /// <summary>
        /// Patients Location ZipCode
        /// </summary>
        public string ZipCode { set { _newPatients.ZipCode = value; } get { return _newPatients.ZipCode; } }

        /// <summary>
        /// Patients FullName
        /// </summary>
        public string FullName => $"{LastName} {FirstName} {MIddleName}";

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
            _newPatients = new PatientModel();

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
            if (!SaveGuard())
                return;

            Patients.patients.Add(_newPatients);

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

        #region Command Guards

        /// <summary>
        /// A Safe Guard for Save Command
        /// </summary>
        /// <returns></returns>
        private bool SaveGuard()
        {
            if (string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(LastName)
                || string.IsNullOrWhiteSpace(MIddleName)
                || Gender == GenderList[0]
                || MaritalStatus == MaritalStatusList[0]
                || string.IsNullOrWhiteSpace(AddressLine1)
                || string.IsNullOrWhiteSpace(City)
                || string.IsNullOrWhiteSpace(State)
                || string.IsNullOrWhiteSpace(Country)
                || string.IsNullOrWhiteSpace(Phone1)
                )
            {
                return false;
            }

            return true;       
        }
        #endregion
    }
}
