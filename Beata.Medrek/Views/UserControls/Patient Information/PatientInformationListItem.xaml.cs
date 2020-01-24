using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for PatientInformationListItem.xaml
    /// </summary>
    public partial class PatientInformationListItem : UserControl
    {
        public PatientInformationListItem()
        {
            InitializeComponent();
        }

        #region IsSelected Dependency Property
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected",
                typeof(bool),
                typeof(PatientInformationListItem),
                new PropertyMetadata(false)); 
        #endregion

        #region InformationItem Dependency Property
        public PatientInformationItems InformationItem
        {
            get { return (PatientInformationItems)GetValue(InformationItemProperty); }
            set { SetValue(InformationItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InformationItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InformationItemProperty =
            DependencyProperty.Register("InformationItem",
                typeof(PatientInformationItems),
                typeof(PatientInformationListItem),
                new PropertyMetadata(default(PatientInformationItems)));
        #endregion

        #region Title Dependency Property

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PatientInformationListItem), new PropertyMetadata(string.Empty));


        #endregion
    }
}
