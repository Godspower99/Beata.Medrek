using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beata.Medrek
{
   public class UnfinishedRegistrationListitemViewModel
    {
        #region Public Properties
        public Patient Patient { get; set; }

        /// <summary>
        /// Item Id for Tracing
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Time of registration
        /// </summary>
        public string Time { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="patient"></param>
        public UnfinishedRegistrationListitemViewModel(Patient patient)
        {
            Patient = patient;
            Time = $"Started {DateTime.Now.ToLongTimeString().ToString()}";
            RemoveItemCommand = new RelayCommand(Remove);
        } 
        #endregion

        #region Commands
        public ICommand RemoveItemCommand { get; set; }
        #endregion

        #region Command Actions

        private void Remove()
        {
            DI.ApplicationViewModel.RemoveUnfinishedRegistrationListItem(this);
           
        }
        #endregion

    }
}
