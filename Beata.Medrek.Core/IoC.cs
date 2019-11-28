
using System;
using Ninject;

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
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
