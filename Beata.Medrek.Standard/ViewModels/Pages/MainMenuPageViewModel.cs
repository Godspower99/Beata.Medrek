using System;
using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Beata.Medrek.Standard
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
        public MainMenuPageViewModel(OperatorModel ops)
        {
            this.Operator = ops;
            LogOutCommand = new RelayCommand(LogOut);
            RegisterCommand = new RelayCommand(Register);
        }

    

        #endregion

        #region Public Properties

        /// <summary>
        /// The Operator Logged In 
        /// </summary>
        public OperatorModel Operator { get; set; }

        /// <summary>
        /// The Name of the operator
        /// </summary>
        public string OperatorName => Operator.Name;

        /// <summary>
        /// The Operator ID
        /// </summary>
        public string OperatorID =>Operator.ID;

        /// <summary>
        /// The Operator Admin Status
        /// </summary>
        public bool OperatorAdminStatus => Operator.IsAdmin;

        /// <summary>
        /// The Operator Login Time
        /// </summary>
        public string OperatorLoginTime => DateTime.Now.ToLongTimeString();

        /// <summary>
        /// The Operator Image
        /// NOTE: CHange to Image From database
        /// </summary>
        public string OperatorImageSource => Operator.ImageSource;

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

        /// <summary>
        /// LogOut Operator
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Method Called when LogOut Command is Activated
        /// </summary>
        private void LogOut()
        {
           // TODO: CLEAR OPERATOR DETAILS ERROR
            // Reset Operator Details 
            // Operator = null;

            // Go Back to Login Page
            IoC.ApplicationViewModel.GotoPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Opens Dialog Box to register a new Patient
        /// </summary>
        private void Register()
        {
            IoC.UiManager.ShowDialog("RegisterPatientUserControl");
        }
        #endregion
    }
}
