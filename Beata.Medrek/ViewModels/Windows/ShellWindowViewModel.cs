using Beata.Medrek.Core;
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
            _window.StateChanged += _window_StateChanged;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Caption Height Of Window
        /// </summary>
        public double TitleHeight { get; set; } = 42;

        /// <summary>
        /// Caption Height Thickness Of Window 
        /// </summary>
        public Thickness TitleHeightThickness
        {
            get
            {
                return new Thickness(TitleHeight);
            }
        }

        /// <summary>
        /// Window Resize Border Value
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// Window Resize Border Value
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(ResizeBorder);
            }
        }

        /// <summary>
        /// Window state flags true if window is maximized
        /// </summary>
        public bool WindowIsMaximized
        {
            get
            {
                return _window.WindowState == WindowState.Maximized;
            }
        }

        /// <summary>
        /// Window Minimum Width
        /// </summary>
        public int MinimumWidth { get; set; } = 800;

        /// <summary>
        /// Window Minimum Height
        /// </summary>
        public int MinimumHeight { get; set; } = 700;
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

        #region Event Listeners

        /// <summary>
        /// Listens For Window State Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _window_StateChanged(object sender, System.EventArgs e)
        {
            OnPropertyChanged(nameof(WindowIsMaximized));
            OnPropertyChanged(nameof(ResizeBorderThickness));
        }
        #endregion

    }
}
