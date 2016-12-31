using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Expense_Tracker
{
    /// <summary>
    /// Relay command implementation of the <see cref="ICommand"/> interface.  This is used by all View Models.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The Action to be executed
        /// </summary>
        protected readonly Action<object> _execute;
        /// <summary>
        /// The predicate determining if <see cref="_execute"/> action can occur.
        /// </summary>
        protected Predicate<object> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The action to be executed.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The action to be executed.</param>
        /// <param name="canExecute">The predite determining if the execution action can be executed.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            //Debug.Assert(execute != null, "Null Execution Parameter");

            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public virtual void Execute(object parameter)
        {
            this._execute(parameter);
        }

        /// <summary>
        /// Sets the can execute.
        /// </summary>
        /// <param name="canExecute">The can execute.</param>
        public void SetCanExecute(Predicate<object> canExecute)
        {
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            return this._canExecute == null ? true : this._canExecute(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}