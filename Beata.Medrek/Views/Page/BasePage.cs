

using System.Windows.Controls;

namespace Beata.Medrek
{
    /// <summary>
    /// A Base Page With Animation Properties and Datacontext Binding 
    /// procedures for other pages to Inherit from
    /// </summary>
    public class BasePage : Page
    {
        #region Private Fields

        /// <summary>
        /// The ViewModel of this page
        /// </summary>
        private BaseViewModel _viewModel;
        #endregion

        #region Public Properties

        /// <summary>
        /// Slide In/Out Animation Time Duration
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// Fade In/Out Animation Time Duration
        /// </summary>
        public float FadeSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The ViewModel of this page
        /// </summary>
        public BaseViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                // Abort if the ViewModel does not change
                if (_viewModel == value)
                    return;

                // Update the ViewModel
                _viewModel = value;

                // Set the DataContext of the page to the ViewModel
                this.DataContext = _viewModel;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // Setting Page Load/Unload Events
            this.Loaded += BasePage_Loaded;
            this.Unloaded += BasePage_Unloaded;
        }

        /// <summary>
        /// Constructor with Specific ViewModel
        /// </summary>
        public BasePage(BaseViewModel specificViewModel)
        {
            //Set DataContext of this Page
            this.ViewModel = specificViewModel;

            // Setting Page Load/Unload Events
            this.Loaded += BasePage_Loaded;
            this.Unloaded += BasePage_Unloaded;

        }
        #endregion

        #region Event handlers

        /// <summary>
        /// Page UnLoaded Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void  BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Animate Page Out On UnLoading
          await PageAnimations.SlideAndFadeOutToLeftAsync((Page)sender, SlideSeconds);

        }

        /// <summary>
        /// Page loaded Event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Animate Page In on Loading
            await PageAnimations.SlideAndFadeInFromRightAsync((Page)sender, SlideSeconds);
        }
        #endregion
    }
}