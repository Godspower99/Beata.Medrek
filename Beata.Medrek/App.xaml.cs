using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceCollection services;
        public static IServiceProvider serviceProvider { get; set; }
        public static IConfiguration Configuration { get; private set; }
        public static DbContextOptionsBuilder<ApplicationDbContext> dbContextOption { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            /// Allow Default Application configuration
            base.OnStartup(e);

            #region Check for better way to get Project Directory

            var env = AppDomain.CurrentDomain.BaseDirectory;
            string dir = Directory.GetParent(Directory.GetParent(env).FullName).FullName;
            string ProjectDirectory = Directory.GetParent(dir).FullName; 
            #endregion

            Configuration = new ConfigurationBuilder()
                  .SetBasePath(ProjectDirectory)
                  .AddJsonFile("appsettings.json")
                  .Build();

            dbContextOption = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("ApplicationConnection"));

            services = new ServiceCollection();

            ConfigureService(services);

            serviceProvider = services.BuildServiceProvider();

            // Ensure Database Migration Exists During Runtime
            new ApplicationDbContext(dbContextOption.Options).Database.Migrate();

            /// Set <see cref=" MainWindow.xaml"/> as MainWindow
            /// And Display it on startup
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();

        }

        private void ConfigureService(IServiceCollection service)
        {
            // Add IConfiguration 
            service.AddSingleton<IConfiguration>(Configuration);

            // Add DbContext to for dependency Injection
            service.AddDbContext<ApplicationDbContext>(option=>
            option.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));

            // Add Application Caching Mechanism for LoggedIn Staff
            service.AddSingleton<IApplicationCache<Staff>,StaffCache>();

            // Add Application ViewModel
            service.AddSingleton<ApplicationViewModel>();

            // Add Application UIManager
            service.AddSingleton<IUIManager, UIManager>();
        }

    }
}
