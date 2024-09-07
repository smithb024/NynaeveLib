namespace NynaeveLib.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Command object.
    /// </summary>
    public class SimpleCommand : ICommand
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="command">action to run when the command is executed.</param>
        public SimpleCommand(Action command)
          : this(command, CanAlwaysRunCommand)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="SimpleCommand"/> class.
        /// </summary>
        /// <param name="command">action to run when the command is executed</param>
        /// <param name="canExecuteCommand">
        /// function which indicates whether the command can be executed
        /// </param>
        public SimpleCommand(
          Action command,
          Func<bool> canExecuteCommand)
        {
            this.RunCommand = command;
            this.CanRunCommand = canExecuteCommand;
        }

        /// <summary>
        /// Run command action.
        /// </summary>
        public Action RunCommand { get; private set; }

        /// <summary>
        /// Can run command function.
        /// </summary>
        public Func<bool> CanRunCommand { get; private set; }

        /// <summary>
        /// Determine if the command can be run.
        /// </summary>
        /// <param name="parameter">not used</param>
        /// <returns>always true</returns>
        public bool CanExecute(object parameter)
        {
            return CanRunCommand();
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
        /// Execute the command
        /// </summary>
        /// <param name="parameter">not used</param>
        public void Execute(object parameter)
        {
            this.RunCommand();
        }

        /// <summary>
        /// Method which always returns true.
        /// </summary>
        /// <returns>always true</returns>
        private static bool CanAlwaysRunCommand()
        {
            return true;
        }
    }
}
