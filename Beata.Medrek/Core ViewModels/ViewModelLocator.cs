
using Microsoft.Extensions.DependencyInjection;

namespace Beata.Medrek
{
    /// <summary>
    /// A ViewModel Locator used in xaml as Path to 
    /// the ApplicationViewModel Singleton in IServiceProvider
    /// </summary>
   public class ViewModelLocator
    {
        /// <summary>
        /// Static Instance of ViewModel Locator
        /// </summary>
        public static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        /// <summary>
        /// returns the ApplicationViewModel Singleton fomr the IoC Kernel
        /// </summary>
        public ApplicationViewModel ApplicationViewModel => App.serviceProvider.GetRequiredService<ApplicationViewModel>();

    }
}
