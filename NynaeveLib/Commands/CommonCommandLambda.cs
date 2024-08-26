namespace NynaeveLib.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// The generic common command class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonCommand<T> : ICommand
    {
        /// <summary>
        /// Initialises a new <see cref="CommonCommand{T}"/> class.
        /// </summary>
        /// <param name="command">The command to run.</param>
        public CommonCommand(Action<T> command)
          : this(command, null)
        {
        }

        public CommonCommand(
          Action<T> command,
          Predicate<T> canExecuteCommand)
        {
            this.RunCommand = command;
            this.CanRunCommand = canExecuteCommand;
        }

        /// <summary>
        /// Run command action.
        /// </summary>
        public Action<T> RunCommand { get; private set; }

        /// <summary>
        /// Can run command function.
        /// </summary>
        public Predicate<T> CanRunCommand { get; private set; }

        /// <summary>
        /// Determine if the command can be run.
        /// </summary>
        /// <param name="parameter">not used</param>
        /// <returns>always true</returns>
        public bool CanExecute(object parameter)
        {
            return this.CanRunCommand == null ? true : this.CanRunCommand((T)parameter);
        }

        /// <summary>
        /// Can execute changed event.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Execute <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter">the object to execute.</param>
        public void Execute(object parameter)
        {
            this.RunCommand((T)parameter);
        }
    }
}
