
using System.Security;
using System.Windows.Controls;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageViewModel>,IHavePassword
    {

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public LoginPage()
        {
           InitializeComponent();
        }

        /// <summary>
        /// Constructor with Specific ViewModel
        /// </summary>
        /// <param name="dataContext"></param>
        public LoginPage(LoginPageViewModel SpecificViewModel):base(SpecificViewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Secure string from the PasswordBox
        /// </summary>
        public SecureString securePassword
        {
            get
            {
                return passwordText.SecurePassword;
            }
        }
    }

}

