
using Ninject;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beata.Medrek.Core
{
 public class LoginPageViewModel:BaseViewModel
    {

        #region Constructor
        public LoginPageViewModel()
        {
            LogInCommand =new RelayParameterizedCommand(async (parameter) => await Login(parameter));
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
            if (IsLogInRunning)
                return;

            IsLogInRunning = true;
           
                await Task.Delay(500);
         
          //  var pass = (parameter as IHavePassword).securePassword.Unsecure();
            IsLogInRunning = false; 
        }
        #endregion
    }
}