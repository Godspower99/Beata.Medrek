using System;

using System.Windows;

namespace Beata.Medrek
{
    ///<Summary>
    /// Implementation of the IUIManager Interface
    ///<Summary>
    public class UIManager : IUIManager
    {
        public void ShowDialog(string Content)
        {
            if (Content == nameof(RegisterPatientUserControl))
                new DialogBox(new RegisterPatientUserControl()).ShowDialog();
        }
    }
}
