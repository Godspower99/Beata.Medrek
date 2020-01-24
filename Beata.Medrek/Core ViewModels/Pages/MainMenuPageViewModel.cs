using System;
using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Beata.Medrek
{
    ///<Summary>
    /// Data Context for MainMenu Page
    ///<Summary>
    public class MainMenuPageViewModel:BaseViewModel
    {
        #region Constructors

        ///<Summary>
        /// Default Constructor for <see="MainMenuPageViewModel"/>
        ///<Summary>
        public MainMenuPageViewModel()
        {
            // Bind Commands to Actions
            RegisterCommand = new RelayCommand(Register);
            SearchCommand = new RelayCommand(Search);
        }

        #endregion

        #region Public Properties

        #endregion

        #region Commands

        /// <summary>
        /// Open Register Dialog
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// Open Search Page
        /// </summary>
        public ICommand SearchCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens Dialog Box to register a new Patient
        /// </summary>
        private void Register()
        {
            // Prompt search with medrek number 
            var result = DI.UiManager.ShowAddNewPatientOptionDialog();

            // if patient has no medrek number 
            if(result==DialogBoxResult.No)
            new AddNewPatientDialog().ShowDialog();

            // TODO :: Talk to Server to retrieve patient Information
        }
       
        private void Search()
        {
            new SearchPage().ShowDialog();
        }
        #endregion
    }
}
