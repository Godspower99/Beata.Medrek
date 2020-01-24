using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for NavigationSideMenuControl.xaml
    /// </summary>
    public partial class NavigationSideMenuControl : UserControl
    {
        public NavigationSideMenuControl()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void Mainmenu_Click(object sender, RoutedEventArgs e)
        {
            DI.ApplicationViewModel.GoToPage(ApplicationPage.MainMenu,new MainMenuPageViewModel());
        }

        private void Newuser_Click(object sender, RoutedEventArgs e)
        {
            // Prompt search with medrek number 
            var result = DI.UiManager.ShowAddNewPatientOptionDialog();

            // if patient has no medrek number 
            if (result == DialogBoxResult.No)
                new AddNewPatientDialog().ShowDialog();

            // TODO :: Talk to Server to retrieve patient Information
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            new SearchPage().ShowDialog();
        }
        #endregion
    }
}
