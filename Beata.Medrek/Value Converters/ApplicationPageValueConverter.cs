
using System;
using System.Diagnostics;
using System.Globalization;

namespace Beata.Medrek
{
    /// <summary>
    /// Application page converts an enum of pages
    /// to an instance of a page class
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:

                    // Check if the parameter is of type CurrentPageViewModel
                    if ((string)parameter ==nameof(DI.ApplicationViewModel.CurrentPageViewModel))

                        // Check if the Application CurrentPageViewModel is LoginPageViewModel
                        if (DI.ApplicationViewModel.CurrentPageViewModel is LoginPageViewModel)
                        return new LoginPage(DI.ApplicationViewModel.CurrentPageViewModel);

                        // else return a default LoginPage;
                    return new LoginPage();

                case ApplicationPage.MainMenu:
                   
                    // Check if the parameter if of type CurrentPageViewModel
                    if ((string)parameter == nameof(DI.ApplicationViewModel.CurrentPageViewModel))
                    
                        // Check if the Application CurrentPageVIewModel is MainMenuPageViewModel
                        if (DI.ApplicationViewModel.CurrentPageViewModel is MainMenuPageViewModel)
                            return new MainMenuPage(DI.ApplicationViewModel.CurrentPageViewModel);
                    
                    // else return a default MainMenuPage;
                    return new MainMenuPage();

                default:
                    // Throw Exception if no page is matched
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
