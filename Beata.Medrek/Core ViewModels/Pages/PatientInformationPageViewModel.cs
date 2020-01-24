using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beata.Medrek
{
    public class PatientInformationPageViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// New Patient to register
        /// </summary>
        public Patient Patient { get; set; } 

        /// <summary>
        /// The patients family contacts
        /// </summary>
        public List<FamilyContact> FamilyContacts { get; set; } = new List<FamilyContact>();

        /// <summary>
        /// The patient Phone Contacts
        /// </summary>
        public PatientPhone Phone { get; set; } = new PatientPhone();

        /// <summary>
        /// Patient Notes
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

        /// <summary>
        /// List of Information Items
        /// </summary>
        public ObservableCollection<PatientInformationListItemModel> ItemsList => new ObservableCollection<PatientInformationListItemModel>
        {
            new PatientInformationListItemModel
            {
                Title="Notes",
                PatientInformation=PatientInformationItems.Notes,
                DisplayPatientInformationCommand=new RelayParameterizedCommand((parameter)=>SetpatientInformation(parameter))
            }
            ,
            new PatientInformationListItemModel
            {
                Title="Family Contacts",
                PatientInformation=PatientInformationItems.FamilyContacts,
                DisplayPatientInformationCommand=new RelayParameterizedCommand((parameter)=>SetpatientInformation(parameter))
            }
        };

        /// <summary>
        /// The Patient Information to display on the table
        /// </summary>
        public object PatientInformation { get; set; } = new object();

        /// <summary>
        /// Display title
        /// </summary>
        public string DisplayTitle { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        public PatientInformationPageViewModel(Patient patient)
        {
            Patient = patient;
            //FamilyContacts = patient.FamilyContacts;
            //Phone = patient.Phone;
            //Notes = patient.Notes;
            //OriginOfBirth = patient.OriginOfBirth;
            //PatientAddress = patient.PatientAddress;
           
            SetPatientInformationCommand = new RelayParameterizedCommand((parameter) => SetpatientInformation(parameter));
        }
        #endregion

        #region Commands

        /// <summary>
        /// Command to change the patient information to display
        /// </summary>
      public  ICommand SetPatientInformationCommand { get; set; }

        #endregion

        #region Command Actions

        /// <summary>
        /// Set Patient Information item for Display 
        /// Command Action
        /// </summary>
        /// <param name="informationitems"></param>
        private void SetpatientInformation(object informationitems)
        {
            switch ((PatientInformationItems)informationitems)
            {
                case PatientInformationItems.FamilyContacts:
                    PatientInformation = Patient.FamilyContacts;
                    DisplayTitle = "Family Contacts";
                    break;

                case PatientInformationItems.Medication:
                    DisplayTitle = "Medications";
                    break;

                case PatientInformationItems.Notes:
                    PatientInformation = Patient.Notes;
                    DisplayTitle = "Notes";
                    break;
            }
        }
        #endregion
    }


    public class PatientInformationListItemModel
    {
        /// <summary>
        /// Item Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Patient Information to Display
        /// </summary>
        public PatientInformationItems PatientInformation { get; set; }

        public ICommand DisplayPatientInformationCommand { get; set; }
    }

    public enum PatientInformationItems
    {
        Medication=0,
        Notes=1,
        FamilyContacts=2,
    }
}
