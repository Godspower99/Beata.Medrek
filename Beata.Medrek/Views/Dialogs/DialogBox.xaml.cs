using System;
using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DialogBox(object Content)
        {
            InitializeComponent();
            this.DataContext = new ShellWindowViewModel(this);
            this.Content =(Content as UserControl);
        }
    }
}