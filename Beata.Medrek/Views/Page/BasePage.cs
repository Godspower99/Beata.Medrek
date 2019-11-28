using Beata.Medrek.Core;
using System.Windows.Controls;

namespace Beata.Medrek
{
    public class BasePage<VM>:Page
        where VM:BaseViewModel,new()
    {
        #region Private Members

        /// <summary>
        /// /The ViewModel Associated with this page
        /// </summary>
        private VM _viewModel;
        #endregion

        #region Constructors
        public BasePage()
        {
            this.ViewModel = new VM();
        }
        #endregion


        #region Public Properties

        /// <summary>
        /// /The ViewModel Associated with this page
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return _viewModel;
            }

            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }
        #endregion

    }
}