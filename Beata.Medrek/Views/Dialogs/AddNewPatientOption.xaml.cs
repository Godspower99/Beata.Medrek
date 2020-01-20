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
    public partial class AddNewPatientOption : Window
    {
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddNewPatientOption()
        {
            InitializeComponent();
            UseMedrekCommand = new RelayCommand(UseMedrek);
            NoMedrekCommand = new RelayCommand(NoMedrek);
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// The Medrek Number To Search with
        /// </summary>
        public string MedrekNo { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The Yes or Ok Button Command
        /// </summary>
        public ICommand UseMedrekCommand { get; set; }

        /// <summary>
        /// The No Button Command
        /// </summary>
        public ICommand NoMedrekCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Ok Command Action
        /// </summary>
        private void UseMedrek()
        {
            DI.UiManager.DialogBoxResult = DialogBoxResult.Yes;
            this.Close();
        }

        private void NoMedrek()
        {
            DI.UiManager.DialogBoxResult = DialogBoxResult.No;
            this.Close();
        }

        #endregion
    }
}