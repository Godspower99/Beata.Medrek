using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Beata.Medrek
{
   public class SearchPatientViewModel:BaseViewModel
    {
        #region Cnstructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        public SearchPatientViewModel(Window dialog)
        {
            _dialog = dialog;

            SearchCommand = new RelayCommand(Search);
            CloseCommand = new RelayCommand(Close);
            ResetCommand = new RelayCommand(Reset);
        }
        #endregion

        #region Private

        /// <summary>
        /// the dialog using this view model
        /// </summary>
        private Window _dialog;
        #endregion

        #region Public Properties

        /// <summary>
        /// The Patient First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The patient Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// List of Patients Found
        /// </summary>
        public ObservableCollection<Patient> PatientsFound { get; set; } = new ObservableCollection<Patient>();

        /// <summary>
        /// Flag for checking if patients have been found
        /// </summary>
        public bool IsSearching { get; set; } = false;

        /// <summary>
        /// flag for Patients Found
        /// </summary>
        public bool FoundPatients { get; set; } = false;

        /// <summary>
        /// flag to control spin text visibility
        /// </summary>
        public bool ShowSpinTextControl { get; set; } = false;

        /// <summary>
        /// Flag used in xaml
        /// </summary>
        public bool ShowSpinText => IsSearching == true && ShowSpinTextControl == true;

        /// <summary>
        /// flag used in xaml for text visibility control
        /// </summary>
        public bool ShowSearchText => FoundPatients == false && ShowSpinTextControl == false;

        #endregion

        #region Commands

        /// <summary>
        /// Command to clear all entry box and found patients
        /// </summary>
        public ICommand ResetCommand { get; set; }

        /// <summary>
        /// Command to Close Dialog
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Search command 
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// Command to Open Patient Information
        /// </summary>
        public ICommand ViewPatientInformationCommand { get; set; }
        #endregion

        #region Command Actions

        /// <summary>
        /// Search Button COmman Action
        /// </summary>
        private async void Search()
        {
            if (IsSearching)
                return;

            PatientsFound.Clear();
            FoundPatients = false;
            IsSearching = true;
            ShowSpinTextControl = true;

            try
            {
                await Task.Run(() =>
                {
                    using (var context = new ApplicationDbContext(DI.DbOptions))
                    {
                        bool found;
                        PatientsFound= context.SearchPatients(FirstName, LastName, out found);

                        if (found == false)
                        {
                            IsSearching = false;
                            ShowSpinTextControl = false;
                            FoundPatients = false;
                            PatientsFound = new ObservableCollection<Patient>();
                            return;
                        }
                        FoundPatients = true;
                    }
                });
            }

            catch(Exception e)
            {
                throw (e);
            }

            finally
            {
                ShowSpinTextControl = false;
                IsSearching = false;
            }
        }

        /// <summary>
        /// Clear entry and found patients command action
        /// </summary>
        private void Reset()
        {
            FirstName = LastName = string.Empty;
            PatientsFound.Clear();
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(PatientsFound));
        }

        /// <summary>
        /// Close dialog command action
        /// </summary>
        private void Close()
        {
            _dialog.Close();
        }
        #endregion
    }
}
