using System.Reflection;

namespace NynaeveLib.Messenger
{
    /// <summary>
    /// Interface for a class which stores an <see cref="Action" /> without a hard reference.
    /// </summary>
    public interface IWeakAction
    {
        /// <summary>
        /// Gets the Action's owner.
        /// </summary>
        object Target { get; }

        /// <summary>
        /// Gets the target of the <see cref="ActionReference"/>.
        /// </summary>
        object ActionTarget { get; }
        /// <summary>
        /// Gets or sets the <see cref="MethodInfo" /> corresponding to this WeakAction's
        /// method passed in the constructor.
        /// </summary>
        MethodInfo Method { get; }

        /// <summary>
        /// Gets a value indicating whether the action's owner is still alive.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Executes an action.
        /// </summary>
        /// <param name="parameter">A parameter passed as an object,
        /// to be casted to the appropriate type.</param>
        void ExecuteWithObject(object parameter);

        /// <summary>
        /// Mark the class for deletion by nulling all values.
        /// </summary>
        void MarkForDeletion();
    }
}
