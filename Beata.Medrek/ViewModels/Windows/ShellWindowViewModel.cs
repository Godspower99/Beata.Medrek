
using System.Windows;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Beata.Medrek
{
   /// <summary>
   /// MainWindow ViewModel/Datacontext
   /// </summary>
   public class ShellWindowViewModel:BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Window This ViewModel Binds To
        /// </summary>
        private Window _window;
        #endregion

        #region Constructor
        /// <summary>
        /// Default ViewModel Constructor
        /// </summary>
        public ShellWindowViewModel(Window window)
        {
            // Create access to the window using this viewmodel
            _window = window;

            // Fix Window Border Resizing Issues
            var windowrResizer = new WindowResizer(_window);

            // set window state changed event handler
            _window.StateChanged += _window_StateChanged;

            // set window OnLoad event handler
            _window.Loaded += _window_Loaded;

            Task.Run(() =>
            {
                while (true)
                    OnPropertyChanged(nameof(SystemTime));
            });

            // Bind Commands to Actions
            CloseCommand = new RelayCommand(Close);
            ShowMenuCommand = new RelayCommand(ShowMenu);
            MinimizeCommand = new RelayCommand(Minimize);
            MaximizeCommand = new RelayCommand(Maximize);
            ShowMenuButtonsCommand = new RelayCommand(ShowMenuButtons);
                
     }

        #endregion

        #region Public Properties

        /// <summary>
        /// Caption Height Of Window
        /// </summary>
        public double TitleHeight { get; set; } = 30;

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

        /// <summary>
        /// Flag sets to true if the window is maximized
        /// </summary>
        public bool IsMaximized { get; set; }


        /// <summary>
        /// Flag sets to true to display Menu Buttons
        /// </summary>
        public bool MenuButtonsVisible { get; set; }

        /// <summary>
        /// System Current Time
        /// </summary>
        public string SystemTime => DateTime.Now.ToLongTimeString();
     
        #endregion
        
        #region Commands

        /// <summary>
        /// Show system menu Command
        /// </summary>
        public ICommand ShowMenuCommand { get; set; } 
        
        /// <summary>
        /// Close Command For Window
        /// </summary>
        public ICommand CloseCommand { get; set; } 

        /// <summary>
        /// Minimize Command For Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Maximize Command For Window
        /// </summary>
        public ICommand MaximizeCommand { get; set;}

        /// <summary>
        /// Toggle the Visibility of the Menu Buttons
        /// </summary>
        public ICommand ShowMenuButtonsCommand { get; set; }
        #endregion

        #region Command Methods

        /// <summary>
        /// Close This Window
        /// </summary>
        private void Close()
        {
            _window.Close();
        }

        /// <summary>
        /// Show Window Menu Method
        /// </summary>
        private void ShowMenu()
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
                  new Point(Mouse.GetPosition(_window).X + _window.Left,
                            Mouse.GetPosition(_window).Y + _window.Top));
            }
        }

        /// <summary>
        /// Minimize this window
        /// </summary>
        private  void Minimize()
        {
            _window.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Maximize this Window
        /// </summary>
        private void Maximize()
        {
            if (_window.WindowState == WindowState.Maximized)
                _window.WindowState = WindowState.Normal;
            else
                _window.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Toggle the Menu buttons visibility 
        /// </summary>
        private void ShowMenuButtons()
        {
            MenuButtonsVisible ^= true;
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Listens For Window State Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _window_StateChanged(object sender, System.EventArgs e)
        {
            // Set IsMaximized Property to true if the window state is maximized
            if (_window.WindowState == WindowState.Maximized)
                IsMaximized = true;

            // Set IsMaximized Property to false if the window state is Normal
            else if (_window.WindowState == WindowState.Normal)
                IsMaximized = false;

            // Fire Change Notification for these Properties
            OnPropertyChanged(nameof(WindowIsMaximized));
            OnPropertyChanged(nameof(ResizeBorderThickness));
        }

        /// <summary>
        /// Window Loaded Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _window_Loaded(object sender, RoutedEventArgs e)
        {
            IsMaximized = _window.WindowState == WindowState.Maximized;
        }
        #endregion

    }
}
