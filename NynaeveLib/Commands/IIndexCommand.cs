namespace NynaeveLib.Commands
{
    using System.Windows.Input;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// Interface which is used to define a view model which will control a single command.
    /// The aim is to be able to link to the command from a view (button) and display a name on it.
    /// When the button is invoked, this in turn invokes a local action which includes the name.
    /// This can be used in collections of commands.
    /// </summary>
    /// <typeparam name="T">Input and action parameter type</typeparam>
    public interface IIndexCommand<T> : IViewModelBase
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Command used to select this object.
        /// </summary>
        ICommand Command { get; }
    }
}
