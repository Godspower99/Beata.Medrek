using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beata.Medrek
{
    /// <summary>
    /// Inversion Of Control Container for Application
    /// </summary>
    public static class DI
    {

        /// <summary>
        /// A singleton of the Application viewmodel used
        /// through the entire application
        /// </summary
        public static ApplicationViewModel ApplicationViewModel => App.serviceProvider.GetRequiredService<ApplicationViewModel>();

        /// <summary>
        /// A singleton of the UIManager 
        /// through the entire application
        /// </summary
        public static IUIManager UiManager => App.serviceProvider.GetRequiredService<IUIManager>();


        /// <summary>
        /// A singleton of the IApplicationCache Implementation 
        /// through the entire application
        /// </summary
        public static IApplicationCache<Staff> StaffCache => App.serviceProvider.GetRequiredService<IApplicationCache<Staff>>();


        /// <summary>
        /// A singleton of the IConfiguration Implementation 
        /// through the entire application
        /// </summary
        public static IConfiguration Configuration => App.serviceProvider.GetRequiredService<IConfiguration>();


        /// <summary>
        /// Application DbContext Option
        /// </summary
        public static DbContextOptions<ApplicationDbContext> DbOptions => App.dbContextOption.Options;
    }
}
