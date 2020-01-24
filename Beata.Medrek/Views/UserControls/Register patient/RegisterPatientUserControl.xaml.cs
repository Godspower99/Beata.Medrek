
using System.Windows.Controls;


namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for RegisterPatientUserControl.xaml
    /// </summary>
    public partial class RegisterPatientUserControl : UserControl
    {
        #region Constructors

        ///<Summary>
        /// Default Constructors
        //</Summary>
        public RegisterPatientUserControl()
        {
            InitializeComponent();
            this.DataContext = new RegisterUserViewModel();
        }

        #endregion
    }
}
