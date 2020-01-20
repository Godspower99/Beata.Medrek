using System.Windows.Controls;


namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : BasePage<MainMenuPageViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();
        }

        public MainMenuPage(MainMenuPageViewModel SpecificViewModel):base(SpecificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}