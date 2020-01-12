using System.Windows.Controls;

namespace Beata.Medrek
{
    public interface IDialogBoxContent
    {
        /// <summary>
        /// Content Of a Dialog Box 
        /// </summary>
        UserControl Content { get; set; }

        /// <summary>
        /// Flag indicating DialogBox ability 
        /// to be minimized
        /// </summary>
        bool CanMinimize { get; set; }
        
    }
}
