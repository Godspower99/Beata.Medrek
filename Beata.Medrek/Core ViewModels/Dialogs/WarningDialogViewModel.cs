using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Beata.Medrek
{
    public class WarningDialogViewModel
    {

        #region Public Properties

        /// <summary>
        /// The Warning Message to Send
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The Warning Mode used For Color Conversion
        /// </summary>
        public WarningMode WarningMode { get; set; }

        #endregion
  
    }
}
