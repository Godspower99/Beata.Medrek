
using Ninject;

namespace Beata.Medrek.Core
{
   public class ViewModelLocator
    {
        /// <summary>
        /// Static Instance of ViewModel Locator
        /// </summary>
        public static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        /// <summary>
        /// returns the ApplicationViewModel Singleton fomr the IoC Kernel
        /// </summary>
        public ApplicationViewModel ApplicationViewModel => IoC.Kernel.Get<ApplicationViewModel>();

    }
}
