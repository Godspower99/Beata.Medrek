using System.Windows;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Window
    {
        public SearchPage()
        {
            InitializeComponent();
            this.DataContext = new SearchPatientViewModel(this);
        }

      
    }
}
