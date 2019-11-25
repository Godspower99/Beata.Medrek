using System.Windows;
using System.Windows.Input;

namespace Beata.Medrek
{
   
   public class ShellWindowViewModel:BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Window This ViewModel Binds To
        /// </summary>
        private static Window _window;
        #endregion

        #region Constructor
        /// <summary>
        /// Default ViewModel Constructor
        /// </summary>
        public ShellWindowViewModel(Window window)
        {
            _window = window;
        }
        #endregion

        #region Public Properties

        #endregion

        #region Commands

        /// <summary>
        /// Show system menu Command
        /// </summary>
        public ICommand ShowMenuCommand { get; set; } = 
            new RelayCommand(() => 
            {
                if (_window.WindowState == WindowState.Maximized)
                {
                    SystemCommands.ShowSystemMenu(_window,
                    new Point(Mouse.GetPosition(_window).X,
                              Mouse.GetPosition(_window).Y));
                }

                else
                {
                    SystemCommands.ShowSystemMenu(_window,
                      new Point(Mouse.GetPosition(_window).X+_window.Left,
                                Mouse.GetPosition(_window).Y+_window.Top));
                }
            });


        /// <summary>
        /// Close Command For Window
        /// </summary>
        public ICommand CloseCommand { get; set; } = new RelayCommand(() => { _window.Close();});

        /// <summary>
        /// Minimize Command For Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; } = new RelayCommand(() => { _window.WindowState = WindowState.Minimized;});

        /// <summary>
        /// Maximize Command For Window
        /// </summary>
        public ICommand MaximizeCommand { get; set; } = 
            new RelayCommand(() => 
            {
                if (_window.WindowState == WindowState.Maximized)
                    _window.WindowState = WindowState.Normal;
                else
                    _window.WindowState = WindowState.Maximized;
            });

        #endregion

        #region Helper Functions

   

        #endregion


    }
}
