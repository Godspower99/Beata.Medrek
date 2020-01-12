using System.Linq;
using Ninject;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Beata.Medrek.Standard
{
    /// <summary>
    /// Login Page ViewModel/Datacontext
    /// </summary>
 public class LoginPageViewModel:BaseViewModel
    {
        #region Constructor
        public LoginPageViewModel()
        {
            LogInCommand =new RelayParameterizedCommand(async (parameter) =>await Login(parameter));
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// User LOGIN ID Information
        /// </summary>
        public string ID { get; set; } 

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
        private async Task Login(object parameter)
        {
            // Terminate Command if Login Command is already running
            if (IsLogInRunning)
                return;

            // Flag IsLogInRunning to true
            IsLogInRunning = true;

            OperatorModel user = null;

            try
            {
                // Loop Over List to find ID Match
                foreach (var ops in Operators.operators)
                    if (ops.ID == ID) { user = ops; }

                // Terminate if no ID is Found
                if (user == null)
                    return;
             
                // If ID is found check for Password
                   if((parameter as IHavePassword).securePassword.Unsecure() == user.Password)
                    {
                        IoC.ApplicationViewModel.GotoPage(ApplicationPage.MainMenu,new MainMenuPageViewModel(user));
                    }
            }
             
            finally
            {
                await Task.Delay(500);
                // Reset Values
                user = null;
                IsLogInRunning = false;
            }
        }
        #endregion
    }
}