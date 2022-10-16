using System.Diagnostics;
using System;
using System.Windows.Input;

namespace AutoSound.Infrastructure.Command.Base;

public class RelayCommand:ICommand
{
    #region Поля

    readonly Action<object> _Execute;
    readonly Predicate<object> _CanExecute;

    #endregion // Поля 

    #region Конструктор

    public RelayCommand(Action<object> execute) : this(execute, null) { }
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        if (execute == null)
        {
            throw new ArgumentNullException("execute");
        }

        _Execute = execute; _CanExecute = canExecute;
    }

    #endregion // Конструктор 

    #region ICommand Члены

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return _CanExecute == null ? true : _CanExecute(parameter);
    }
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    public void Execute(object parameter) { _Execute(parameter); }


    #endregion // ICommand Члены

}