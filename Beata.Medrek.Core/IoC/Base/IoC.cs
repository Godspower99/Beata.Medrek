using System;
using Ninject;
using Microsoft.EntityFrameworkCore;

namespace Beata.Medrek.Core
{
    /// <summary>
    /// Inversion Of Control Container for Application
    /// </summary>
   public static class IoC
    {
        /// <summary>
        ///IoC kernel object
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A singleton of the Application viewmodel used
        /// through the entire application
        /// </summary
        public static ApplicationViewModel ApplicationViewModel => IoC.Kernel.Get<ApplicationViewModel>();

        /// <summary>
        /// A singleton of the UIManager 
        /// through the entire application
        /// </summary
        public static IUIManager UiManager=> IoC.Kernel.Get<IUIManager>();

        /// <summary>
        /// Ioc Configuration method
        /// Note:To be called when application starts up
        /// </summary>
        public static void Configure()
        {
            BindViewModels();
        }

        /// <summary>
        /// Method for Binding ViewModels to IoC Kernel
        /// </summary>
        private static void BindViewModels()
        {
            // Create and bind a singleton of the ApplicationViewModel to the IoC Kernel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            // Create and bind a singleton of the Application Connection to the database for Managing Login
            var options = new ServerConnectionDetails
            {
                DatabaseName = "Hospital",
                TrustedConnection="true",
                ServerName="OTIETE\\SQLEXPRESS",
                AllowMultipleResultSet="true"
            };
            var optionsBuilder = new DbContextOptionsBuilder().UseSqlServer(options.ConnectionString);
            ApplicationViewModel.Connection = new ApplicationConnection(optionsBuilder);

            //Bind Singleton of the Staff Caching Mechanism 
            ApplicationViewModel.StaffCache = new StaffCache();
        }
    }
}
