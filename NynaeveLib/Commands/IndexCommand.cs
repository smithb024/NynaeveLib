namespace NynaeveLib.Commands
{
    using System;
    using System.Windows.Input;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A view model which will control a single command. The aim is to be able to link to the 
    /// command from a view (button) and display a name on it.
    /// When the button is invoked, this in turn invokes a local action which includes the name.
    /// This can be used in collections of commands.
    /// </summary>
    /// <typeparam name="T">Input and action parameter type</typeparam>
    public class IndexCommand<T> : ViewModelBase, IIndexCommand<T>
    {
        /// <summary>
        /// Command to run when this <see cref="IndexCommand"/> is actioned.
        /// </summary>
        Action<T> command;

        /// <summary>
        /// The name of the <see cref="IndexCommand{T}"/>.
        /// </summary>
        T name;

        /// <summary>
        /// Initialises a new instance of the <see cref="IndexCommand{T}"/> class.
        /// </summary>
        /// <param name="name">Index command name</param>
        /// <param name="command">
        /// The method to invoke when this command is actioned.
        /// </param>
        public IndexCommand(
            T name,
            Action<T> command)
        {
            this.name = name;
            this.command = command;

            this.Command =
                new CommonCommand(
                    this.Invoke);
        }

        /// <summary>
        /// Gets the name of the <see cref="IndexCommand{T}"/> as a string.
        /// </summary>
        public string Name => this.name.ToString();

        /// <summary>
        /// Command used to action this object.
        /// </summary>
        public ICommand Command { get; }

        /// <summary>
        /// Invoke the current command.
        /// </summary>
        private void Invoke()
        {
            this.command.Invoke(this.name);
        }
    }
}
