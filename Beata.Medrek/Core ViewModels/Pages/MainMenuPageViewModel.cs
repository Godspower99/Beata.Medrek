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
            LogOutCommand = new RelayCommand(LogOut);
            RegisterCommand = new RelayCommand(Register);
        }

        #endregion

        #region Public Properties

        public Staff staff => DI.StaffCache.Object;
        /// <summary>
        /// Staff FullName
        /// </summary>
        public string StaffName => $"{staff.LastName} {staff.FirstName} {staff.Middle}";

        /// <summary>
        /// Staff UserName
        /// </summary>
        public string UserName=> staff.UserName;

        /// <summary>
        /// Staff Admin Status
        /// </summary>
        public bool AdminStatus => staff.IsAdmin;

        /// <summary>
        /// Staff Login Time
        /// </summary>
        public string StaffLoginTime => DateTime.Now.ToLongTimeString();


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
           
           using(var dbContext=new ApplicationDbContext(DI.DbOptions))
            {
                dbContext.StaffLogout();

                // Go Back to Login Page
                DI.ApplicationViewModel.GotoPage(ApplicationPage.Login);
            }

        }

        /// <summary>
        /// Opens Dialog Box to register a new Patient
        /// </summary>
        private void Register()
        {
            DI.UiManager.ShowDialog("RegisterPatientUserControl");
        }
        #endregion
    }
}
