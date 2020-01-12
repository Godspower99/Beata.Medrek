
using System.Security;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage,IHavePassword
    {

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public LoginPage():base(new LoginPageViewModel())
        {
           InitializeComponent();
        }

        /// <summary>
        /// Constructor with Specific ViewModel
        /// </summary>
        /// <param name="dataContext"></param>
        public LoginPage(BaseViewModel dataContext):base(dataContext)
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

