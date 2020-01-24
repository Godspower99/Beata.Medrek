using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beata.Medrek
{
    /// <summary>
    /// Login Page ViewModel/Datacontext
    /// </summary>
    public class LoginPageViewModel:BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginPageViewModel()
        {
            // Bind Commands to Actions
            LogInCommand =new RelayParameterizedCommand(async (parameter) => await Login(parameter));
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
        /// Logging Command:: Interface for calling logging Action with parameter 
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

            try
            {
                await Task.Run(async () =>
                {
                    // Open new Database Connection with IDisposable
                    using (var dbContext = new ApplicationDbContext(DI.DbOptions))
                    {
                        Staff User = dbContext.StaffLogin(UserName,
                            (parameter as IHavePassword).securePassword.Unsecure(),
                            out bool Granted);

                        if (Granted == true)
                        {
                            // Call Application to Handle Succefull login
                          DI.ApplicationViewModel.HandleSuccessfulLogin(User);
                        }

                        else
                        {
                            DI.ApplicationViewModel.ShowNotification("Wrong Username or Password\nEnter Correct Credentials!", NotificationMode.error);
                        }

                    }
                });
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