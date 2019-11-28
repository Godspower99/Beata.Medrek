using System;
using System.Windows.Input;
namespace Beata.Medrek.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private Action _action;

        /// <summary>
        /// Default Constructors 
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// CanExecute Command to guide command execution
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }


        /// <summary>
        /// Execute Command for running action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
