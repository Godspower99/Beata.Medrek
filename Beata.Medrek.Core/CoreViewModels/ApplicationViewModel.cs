namespace Beata.Medrek.Core
{
    /// <summary>
    /// The ApplicationViewModel used through the entire application
    /// </summary>
   public class ApplicationViewModel:BaseViewModel
    {
        #region Public Properties
        
        /// <summary>
        /// Current Page Of the Application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// Application Database Connection
        /// </summary>
        public ApplicationConnection Connection { get; set; }

        /// <summary>
        /// Application Staff Caching Mechanism
        /// </summary>
        public IApplicationCache<Staff> StaffCache { get; set; }

        /// <summary>
        /// Specific DataContext for the Current Page
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        #endregion

        #region public Methods

        /// <summary>
        /// Page Navigation Function amd Control
        /// </summary>
        /// <param name="page"></param>
        public void GotoPage(ApplicationPage page, BaseViewModel specificViewModel=null)
        {
            // Set the Current page to the Method Argument
            CurrentPage = page;
            CurrentPageViewModel = specificViewModel;

            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(CurrentPageViewModel));
        } 
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationViewModel()
        {

        }
        #endregion

    }
}
