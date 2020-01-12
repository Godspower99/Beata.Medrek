using System.Windows.Controls;


namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : BasePage
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with Specific ViewModel
        /// </summary>
        /// <param name="specificViewModel"></param>
        public MainMenuPage(BaseViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}