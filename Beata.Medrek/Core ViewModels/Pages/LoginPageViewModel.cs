using System.Linq;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Beata.Medrek
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
                var staff = new Staff
                {
                    FirstName = "Godspower",
                    LastName = "otiete",
                    IsAdmin = false,
                    Password = "qwerty12",
                    UserName = "Daemon",
                    Position = "Doctor",
                    PrimaryPhone = "08105609572",
                    Title = "Mr",

                };

                var patient = new Patient
                {
                    LastName = "Otiete",
                    FirstName = "Godspower",
                    Gender = "Male",
                    MedRekNO = "Medrek",
                    DateOfBirth = DateTime.Now,
                    MaritalStatus="Single",
                    RegistrationTime=DateTime.Now,
                    
                };

                // Test CRUD EXTENSIONS

                //using (var context = new ApplicationDbContext(DI.DbOptions))
                //{
                //   var test1= context.AddPatient(patient);
                //   var test2= context.FindPatient(patient);
                //    var test3 = context.GetAllPatients();
                //    var test4 = context.DeletePatient(patient);
                //}


                using (var dbContext = new ApplicationDbContext(DI.DbOptions))
                {
                    Staff User = dbContext.StaffLogin(UserName,
                    (parameter as IHavePassword).securePassword.Unsecure(),
                    out bool Granted);

                    if (Granted == true)
                    {
                        DI.StaffCache.SetObject(User);
                        DI.ApplicationViewModel.GotoPage(ApplicationPage.MainMenu, new MainMenuPageViewModel());
                    }

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