using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beata.Medrek
{    
    /// <summary>
    /// Interaction logic for AddNewPatientPage.xaml
    /// </summary>
    public partial class AddNewPatientDialog : Window
    {
        public AddNewPatientDialog()
        {
            InitializeComponent();
            this.DataContext = new AddNewPatientDialogViewModel(this);
        }

        /// <summary>
        /// Window Id for tracking in list
        /// </summary>
        public int ID { get; set; } 
    }
}
