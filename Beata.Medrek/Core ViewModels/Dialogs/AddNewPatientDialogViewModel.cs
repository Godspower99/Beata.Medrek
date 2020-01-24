using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Beata.Medrek
{
    public class AddNewPatientDialogViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The Dialog this ViewModel is attached to
        /// </summary>
        private Window _dialog;
        #endregion

        #region Public Properties

        /// <summary>
        /// New Patient to register
        /// </summary>
        public Patient Patient { get; set; } = new Patient();

        /// <summary>
        /// The patients family contacts
        /// </summary>
        public List<FamilyContact> FamilyContacts { get; set; } = new List<FamilyContact>();

        /// <summary>
        /// The patient Phone Contacts
        /// </summary>
        public PatientPhone Phone { get; set; } = new PatientPhone();

        /// <summary>
        /// Patient NOtes
        /// </summary>
        public List<PatientsNotes> Notes { get; set; } = new List<PatientsNotes>();

        /// <summary>
        /// Patient Origin of Birth Information
        /// </summary>
        public PatientOriginOfBirth OriginOfBirth { get; set; } = new PatientOriginOfBirth();

        /// <summary>
        /// Patient Address Information
        /// </summary>
        public PatientAddress PatientAddress { get; set; } = new PatientAddress();
        #endregion

        #region DropDown List Items

        /// <summary>
        /// Gender List
        /// </summary>
        public List<string> GenderList => new List<string>() { "--Select--","Female", "Male" };

        /// <summary>
        /// Marital Status List
        /// </summary>
        public List<string> MaritalStatusList => new List<string>()
        {
            "--Select--",
            "Single",
            "Married"
        };

        #endregion

        #region Commands
        /// <summary>
        /// Command For minimizing the Dialog
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command For Saving The New patient To The Database
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Command for cancelling and closing the Dialog
        /// </summary>
        public ICommand CancelCommand { get; set; }
        #endregion

        #region Command Actions

        /// <summary>
        /// Minimize Command Action
        /// </summary>
        private void Minimize()
        {
            // Minimize dialog and add it to unfinished registrations List
            DI.ApplicationViewModel.AddUnfinishedRegistrationListItem(_dialog); 
        }

        /// <summary>
        /// Closes The Window,
        /// Canceling transaction after confirmation
        /// </summary>
        private void Close()
        {
            var result = DI.UiManager
                .ShowWarningDialog(new WarningDialogViewModel {
                    Message="Cancel Registration ?",
                    WarningMode=WarningMode.Red
                });

            if (result == DialogBoxResult.No)
                return;
            _dialog.Close();
        }

        /// <summary>
        /// Save Patient to the Database
        /// After Confirmation
        /// </summary>
        private void Save()
        {
            if (ModelValidation())
            {
                Patient.Phone = Phone;
                Patient.PatientAddress = PatientAddress;
                Patient.OriginOfBirth = OriginOfBirth;
                Patient.FamilyContacts = FamilyContacts;
                Patient.RegistrationTime = DateTime.Now;
                Patient.MedRekNO = GenerateMedRekNO();

                var result = DI.UiManager.ShowWarningDialog(new WarningDialogViewModel
                {
                    Message = "Complete Regsitration?",
                    WarningMode = WarningMode.Green
                });

                if(result==DialogBoxResult.Yes)
                using(var context=new ApplicationDbContext(DI.DbOptions))
                {
                    try
                    {
                            context.AddPatient(Patient);
                            DI.ApplicationViewModel.ShowNotification(message: "New Patient Registered!", NotificationMode.success);
                            _dialog.Close();
                            return;
                    }

                    catch (Exception e)
                    {
                        throw (e);
                    }
                }
            }

            
            DI.ApplicationViewModel.ShowNotification(message: "Please Fill all Required Fields", NotificationMode.error);
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddNewPatientDialogViewModel(Window dialog)
        {
            _dialog = dialog;

            // Bind Commands to actions
            MinimizeCommand = new RelayCommand(Minimize);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Close);
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Model Validation to Check
        /// all Required fields has been entered
        /// </summary>
        /// <returns></returns>
        private bool ModelValidation()
        {
            if (!string.IsNullOrWhiteSpace(Patient.LastName))
                if (!string.IsNullOrWhiteSpace(Patient.FirstName))
                    if (!string.IsNullOrWhiteSpace(Phone.PrimaryPhone))
                        if (!string.IsNullOrWhiteSpace(PatientAddress.PrimaryAddress))
                            if (!string.IsNullOrWhiteSpace(OriginOfBirth.Country))
                                if (!string.IsNullOrWhiteSpace(OriginOfBirth.State))
                                    if (!string.IsNullOrWhiteSpace(OriginOfBirth.LGA))
                                        return true;
            return false;
                              
        }

        /// <summary>
        /// Demo:: MedRekNO Generator 
        /// TODO IMPORTANT:: update later to generate truly unique values
        /// </summary>
        /// <returns></returns>
        private string GenerateMedRekNO()
        {
            string firstletter = Patient.LastName[0].ToString().ToUpper();
            string secondletter = Patient.FirstName[0].ToString().ToUpper();

            return $"{firstletter}{secondletter}{Patient.Phone.PrimaryPhone}";
        }
        #endregion
    }
}
