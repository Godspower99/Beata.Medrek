using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Beata.Medrek
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
        /// Specific DataContext for the Current Page
        /// </summary>
        public object CurrentPageViewModel { get; set; } 

        /// <summary>
        /// Flag for Enabling and Disabling Side Menu Visibility
        /// </summary>
        public bool CanShowSidemenu { get; set; } = false;

        /// <summary>
        /// Flag to toggling Staff Details Visibility
        /// </summary>
        public bool ShowStaffDetailsVisible { get; set; } = false;

        /// <summary>
        /// Staff  Details Visibility Control for Animation Set in Xaml
        /// </summary>
        public bool ShowStaffDetailsControl => CanShowSidemenu == true && ShowStaffDetailsVisible == true;

        /// <summary>
        /// Navigation Menu Visibility Control Used in Xaml
        /// </summary>
        public bool ShowNavigationControl => CanShowSidemenu == true && ShowStaffDetailsVisible == false;

        /// <summary>
        /// Flag For Toggling Notification
        /// </summary>
        public bool ShowNotificationControl { get; set; }

        /// <summary>
       /// Notification mode
       /// </summary>
        public NotificationMode NotificationMode { get; set; }

        /// <summary>
        /// notification Message
        /// </summary>
        public string NotificationMessage { get; set; }

        /// <summary>
        /// The Current LoggedIn Staff
        /// </summary>
        public Staff LoggedInStaff { get; set; }

        /// <summary>
        /// List of UNnfinished Registration windows 
        /// </summary>
        public List<AddNewPatientDialog> UnfinishedRegistrationList { get; set; } = new List<AddNewPatientDialog>();

        /// <summary>
        /// List of unfinished registration Items
        /// </summary>
        public ObservableCollection<UnfinishedRegistrationListitemViewModel> UnfinishedRegistrationListItems { get; set; } = new ObservableCollection<UnfinishedRegistrationListitemViewModel>();

        /// <summary>
        /// Unfinished registration control switch
        /// </summary>
        public bool ShowUnfinishedRegistrationSwitch { get; set; } = false;

        /// <summary>
        /// Unfinished Registration Item List Control Switch
        /// </summary>
        public bool ShowUnfinishedRegistrationListSwitch { get; set; } = false;

        /// <summary>
        /// Actual control Switch for Unfinished Registration control
        /// </summary>
        public bool ToggleUnfinishedRegistrationSwitchControl => CanShowSidemenu == true && ShowUnfinishedRegistrationSwitch == true;

        /// <summary>
        /// Actual Control switch for unfinished registration list
        /// </summary>
        public bool ToggleUnfinishedRegistrationListControl => ToggleUnfinishedRegistrationSwitchControl == true && ShowUnfinishedRegistrationListSwitch == true;

        /// <summary>
        /// The number of unfinished registration dialogs
        /// </summary>
        public int NumberOfUnfinishedRegistrationDialog { get; set; }= 0;

        /// <summary>
        /// Flag for setting visibility of background if any 
        /// dialog window is open
        /// </summary>
        public bool DialogActive { get; set; } = false;

        #endregion

        #region Commands
        /// <summary>
        /// Command For Toggling Staff Details Control Visibility
        /// </summary>
        public ICommand ToggleStaffControlCommand { get; set; }

        /// <summary>
        /// Command For Toggling Navigation Menu Visibility
        /// </summary>
        public ICommand ToggleNavigationControlCommand { get; set; }

        /// <summary>
        /// Command For handling User Logging Out
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        /// <summary>
        /// Command to display and remove Unfinished item dialog from list
        /// </summary>
        public  ICommand RemoveUnfinishedRegistrationListItemCommand { get; set; }

        /// <summary>
        /// Command to minimize and Add Unfinished Item dialog to list
        /// </summary>
        public ICommand AddUnfinishedRegistrationListItemCommand { get; set; }

        /// <summary>
        /// Command for controlling visibility of Unfinished registration List
        /// </summary>
        public ICommand ToggleUnfinishedRegistrationListControlCommand { get; set; }

        /// <summary>
        /// Command to clear All UnfinishedRegistrationItem in list
        /// </summary>
        public ICommand ClearAllUnfinishedRegistrationCommand { get; set; }
        #endregion

        #region public Methods

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, object viewModel = null)
        {
            // Set the view model
            CurrentPageViewModel = viewModel;

            // See if page has changed
            var different = CurrentPage != page;

            // Set the current page
            CurrentPage = page;

            // If the page hasn't changed, fire off notification
            // So pages still update if just the view model has changed
            if (!different)
                OnPropertyChanged(nameof(CurrentPage));

            CanShowSidemenu = !(page == ApplicationPage.Login);

        }

        /// <summary>
        /// Notification Dialog Control
        /// </summary>
        /// <param name="message"></param>
        /// <param name="duration"></param>
        /// <param name="mode"></param>
        public async void ShowNotification(string message,NotificationMode mode, int duration = 3)
        {
            NotificationMessage = message;
            NotificationMode = mode;
            ShowNotificationControl = true;
            await Task.Delay(duration * 1000);
            ShowNotificationControl = false;
        }

        /// <summary>
        /// Successfull Staff Login Handler
        /// </summary>
        /// <param name="staff"></param>
        public async void HandleSuccessfulLogin(Staff staff)
        {
            // Memory Cache of Current Logged in Staff
            LoggedInStaff= staff;
            
           ShowNotification("Welcome!", NotificationMode.success);
            await Task.Delay(500);

            // Navigate to MainMenu
            GoToPage(ApplicationPage.MainMenu, new MainMenuPageViewModel());
        }

        #endregion


        #region Command Actions
        
        /// <summary>
        /// Staff navigation COntrol ACtion
        /// </summary>
        private void ToggleStaffNavigation()
        {
            ShowStaffDetailsVisible = false;
        }

        /// <summary>
        /// Navigtion Menu Toggle Action
        /// </summary>
        private void ToggleNavigationControl()
        {
            ShowStaffDetailsVisible = true;
        }

        /// <summary>
        /// LogOut Command Action
        /// </summary>
        private async void LogOut()
        {
            // Check number of unfinished Registrations
            // and Prompt if available
            if (NumberOfUnfinishedRegistrationDialog > 0)
            {
                var result = DI.UiManager
                    .ShowWarningDialog(new WarningDialogViewModel
                    {
                        Message = "Unfinished Patient Registrations.\nClear All?",
                        WarningMode = WarningMode.Red
                    });
                if (result == DialogBoxResult.Yes)
                    ClearAllUnfinishedRegistration();
                else
                    return;
            }

            await Task.Run(() =>
            {
                // Reset Memory cache of current logged in staff
                LoggedInStaff = null;

                ShowStaffDetailsVisible = false;

                // Navigate to Login page
                GoToPage(ApplicationPage.Login);
            });
        }

        /// <summary>
        /// AddUnfinishedRegistrationListItem Command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void AddUnfinishedRegistrationListItem(object parameter)
        {
            // Parse Parameter as AddNewPatientDialog Object
            var par = (parameter as AddNewPatientDialog);

            // Register ID of Unfinished Registration Dialog 
            par.ID = NumberOfUnfinishedRegistrationDialog + 1;

            // Add Dialog To Storage List and Unfinished Registration Item ViewModel to an Observable Collection
            UnfinishedRegistrationList.Add(par);
            UnfinishedRegistrationListItems.Add(new UnfinishedRegistrationListitemViewModel((par.DataContext as AddNewPatientDialogViewModel).Patient) { ID = par.ID });
            NumberOfUnfinishedRegistrationDialog += 1;

            // Notify of property changes ::Just in case :)
            OnPropertyChanged(nameof(NumberOfUnfinishedRegistrationDialog));
            OnPropertyChanged(nameof(UnfinishedRegistrationListItems));

            // Hide The dialog Window
            par.Hide();

            // Verify Number of Unfinished Registration
            CheckNumberOfUnfinishedRegistration();
        }

        /// <summary>
        /// Command Action to Remove Unfinished Registration Dialog From Storage List
        /// And Also Display It 
        /// </summary>
        /// <param name="parameter"></param>
        public void RemoveUnfinishedRegistrationListItemAction(object parameter)
        {
           var param =(int)parameter;
            // Get the dialog and Item using its tracking ID
            var win= UnfinishedRegistrationList.FirstOrDefault(p => p.ID == param);
            var item = UnfinishedRegistrationListItems.FirstOrDefault(p => p.ID == param);

            // Remove dialog and Item and Notify Properties just in case :)
            UnfinishedRegistrationList.Remove(win);
            UnfinishedRegistrationListItems.Remove(item);
            OnPropertyChanged(nameof(NumberOfUnfinishedRegistrationDialog));
            NumberOfUnfinishedRegistrationDialog -= 1;

            //Display Dialog and Check Number of UnFinished Registrations
            CheckNumberOfUnfinishedRegistration();
            win.ShowDialog();
           
        }

        /// <summary>
        /// Command Action to Remove the Unfinished registration item 
        /// from the Observable Collection an also delete it from the main list
        /// </summary>
        /// <param name="item"></param>
        public void RemoveUnfinishedRegistrationListItem(UnfinishedRegistrationListitemViewModel item)
        {
            // Fetch the item and its corresponding dialog using its tracking id 
            var listitem = UnfinishedRegistrationListItems.FirstOrDefault(p => p.ID == item.ID);
            var winditem = UnfinishedRegistrationList.FirstOrDefault(p => p.ID == listitem.ID);

            // Remove the dialog and item from their lists then close the dialog
            UnfinishedRegistrationList.Remove(winditem);
            UnfinishedRegistrationListItems.Remove(listitem);
            NumberOfUnfinishedRegistrationDialog -= 1;
            winditem.Close();

            // Check number of Unfinished Registrations
            CheckNumberOfUnfinishedRegistration();
        }

        /// <summary>
        /// Command Action for ToggleUnfinishedRegistrationListControlCommand 
        /// </summary>
        public void ToggleUnfinishedRegistrationListControlAction()
        {
            ShowUnfinishedRegistrationListSwitch = ShowUnfinishedRegistrationListSwitch == true ? false : true;
        }

        /// <summary>
        /// Clear all items from the list and delete corresponding dialogs
        /// </summary>
        public void ClearAllUnfinishedRegistration()
        {
            // Clear all unfinished registration list items and close corresponding windows
            foreach (UnfinishedRegistrationListitemViewModel un in UnfinishedRegistrationListItems)
            {
                var winitem = UnfinishedRegistrationList.FirstOrDefault(p => p.ID == un.ID);
                winitem.Close();
            }
            UnfinishedRegistrationListItems.Clear();
            UnfinishedRegistrationList.Clear();
            NumberOfUnfinishedRegistrationDialog = 0;
            CheckNumberOfUnfinishedRegistration();
        }

        /// <summary>
        /// method for Checking the number of unfinished registration dialogs 
        /// and updating dependent properties
        /// </summary>
        private void CheckNumberOfUnfinishedRegistration()
        {
            if (NumberOfUnfinishedRegistrationDialog <= 0)
            {
                ShowUnfinishedRegistrationSwitch = false;
                ShowUnfinishedRegistrationListSwitch = false;
            }
            else if (NumberOfUnfinishedRegistrationDialog > 0)
                ShowUnfinishedRegistrationSwitch = true;
            OnPropertyChanged(nameof(ShowUnfinishedRegistrationSwitch));
            OnPropertyChanged(nameof(ToggleUnfinishedRegistrationSwitchControl));
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationViewModel()
        {
            // Bind Commands to Actions
            ToggleStaffControlCommand = new RelayCommand(ToggleStaffNavigation);
            ToggleNavigationControlCommand = new RelayCommand(ToggleNavigationControl);
            LogOutCommand = new RelayCommand(LogOut);
            AddUnfinishedRegistrationListItemCommand = new RelayParameterizedCommand((parameter) => AddUnfinishedRegistrationListItem(parameter));
            ToggleUnfinishedRegistrationListControlCommand = new RelayCommand(ToggleUnfinishedRegistrationListControlAction);
            ClearAllUnfinishedRegistrationCommand = new RelayCommand(ClearAllUnfinishedRegistration);
            RemoveUnfinishedRegistrationListItemCommand = new RelayParameterizedCommand((parameter) => RemoveUnfinishedRegistrationListItemAction(parameter));
        }
        #endregion

    }
}
