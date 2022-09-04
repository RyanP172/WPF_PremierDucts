using System;
using System.Windows.Input;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canexecute;

        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)//canExecute is optional so put it can be null
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canexecute = canExecute;
        }
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => _canexecute is null || _canexecute(parameter);
        //public bool CanExecute(object? parameter)=> _canexecute is null ? true : _canexecute(parameter); 
        //return _canExecute and let's check if that _canExecute field is null
        //if that is the case, return true
        //else, return the result of the CanExecute delegate
        public void Execute(object? parameter) => _execute(parameter);
        
    }
}
