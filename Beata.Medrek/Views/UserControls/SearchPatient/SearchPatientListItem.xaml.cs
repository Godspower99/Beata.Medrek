using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Beata.Medrek
{
    /// <summary>r
    /// Interaction logic for SearchPatientListItem.xaml
    /// </summary>
    public partial class SearchPatientListItem : UserControl
    {
        public SearchPatientListItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens Patient Information Page 
        /// With Patient Information As Parameter
        /// Also closing the Containing window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Close();
            DI.ApplicationViewModel.GoToPage(ApplicationPage.PatientInformation, this.DataContext as Patient);
        }
    }
}
