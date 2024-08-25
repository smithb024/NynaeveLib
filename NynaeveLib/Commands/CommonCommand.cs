namespace NynaeveLib.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Command class.
    /// </summary>
    public class CommonCommand : ICommand
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CommonCommand"/> class.
        /// </summary>
        /// <param name="command">The action to run.</param>
        public CommonCommand(Action command)
          : this(command, CanAlwaysRunCommand)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CommonCommand"/> class.
        /// </summary>
        /// <param name="command">The action to run.</param>
        /// <param name="canExecuteCommand">
        /// A function which indicates when the <paramref name="command"/> can be run.
        /// </param>
        public CommonCommand(
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
            return this.CanRunCommand();
        }

        /// <summary>
        /// Can execute changed event.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

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
