using System;

using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
    ///<Summary>
    /// Implementation of the IUIManager Interface
    ///<Summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Warning DialogBox results used for tracking 
        /// dialog box user response
        /// </summary>
        public DialogBoxResult DialogBoxResult { get; set; }

        public DialogBoxResult ShowAddNewPatientOptionDialog()
        {
            DI.ApplicationViewModel.DialogActive = true;
            new AddNewPatientOption().ShowDialog();
            DI.ApplicationViewModel.DialogActive = false;
            return DialogBoxResult;
        }

        public void ShowDialog(object obj)
        {
          if(obj is UserControl)
            {
                new DialogBox(obj).ShowDialog();
            }
        }

        public DialogBoxResult ShowWarningDialog(WarningDialogViewModel warningModel)
        {
            DI.ApplicationViewModel.DialogActive = true;
            new WarningDialog(warningModel).ShowDialog();
            DI.ApplicationViewModel.DialogActive = false;
            return DialogBoxResult;
        }
    }
}
