using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Beata.Medrek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WarningDialog : Window
    {
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WarningDialog(WarningDialogViewModel warningModel)
        {
            InitializeComponent();
            this.DataContext = warningModel;
            YesCommand = new RelayCommand(Yes);
            NoCommand = new RelayCommand(No);
        }
        #endregion

        #region Commands

        /// <summary>
        /// The Yes or Ok Button Command
        /// </summary>
        public ICommand YesCommand { get; set; }

        /// <summary>
        /// The No Button Command
        /// </summary>
        public ICommand NoCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Ok Command Action
        /// </summary>
        private void Yes()
        {
            DI.UiManager.DialogBoxResult = DialogBoxResult.Yes;
            this.Close();
        }

        private void No()
        {
            DI.UiManager.DialogBoxResult = DialogBoxResult.No;
            this.Close();
        }

        #endregion
    }
}