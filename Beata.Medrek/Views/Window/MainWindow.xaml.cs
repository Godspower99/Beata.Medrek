using System;
using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ShellWindowViewModel(this);
        }

        
       
        #region Event Handlers
        private void menu_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var grid = (sender as Grid);
            ((ShellWindowViewModel)this.DataContext).MenuButtonsVisible = true;
        }

        private void menu_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((ShellWindowViewModel)this.DataContext).MenuButtonsVisible = false;
        }

        #endregion
    }
}