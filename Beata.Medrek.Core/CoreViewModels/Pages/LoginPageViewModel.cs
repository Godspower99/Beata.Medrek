using System.Linq;
using Ninject;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Beata.Medrek.Core
{
    /// <summary>
    /// Login Page ViewModel/Datacontext
    /// </summary>
 public class LoginPageViewModel:BaseViewModel
    {
        #region Constructor
        public LoginPageViewModel()
        {
            LogInCommand =new RelayParameterizedCommand((parameter)=> Login(parameter));
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Staff UserName
        /// </summary>
        public string UserName { get; set; } 

        /// <summary>
        /// Flag indicating if logging command is running
        /// </summary>
        public bool IsLogInRunning { get; set; } = false;
        #endregion

        #region Commands

        /// <summary>
        /// Logging Command Interface for calling logging Action with parameter 
        /// </summary>
        public ICommand LogInCommand { get; set; }
        
        #endregion

        #region Actions

        /// <summary>
        /// Login Action called By LogInCommand  
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private void Login(object parameter)
        {
            // Terminate Command if Login Command is already running
            if (IsLogInRunning)
                return;

            // Flag IsLogInRunning to true
            IsLogInRunning = true;

            
            try
            {
              Staff User = IoC.ApplicationViewModel.Connection.StaffLogin(UserName, (parameter as IHavePassword).securePassword.Unsecure(),out bool Granted);

                if (Granted == true)
                {
                    IoC.ApplicationViewModel.StaffCache.Object = User;
                    IoC.ApplicationViewModel.GotoPage(ApplicationPage.MainMenu, new MainMenuPageViewModel());
                }


            }
             
            finally
            {

                // Reset Values
                IsLogInRunning = false;
            }
        }
        #endregion
    }
}