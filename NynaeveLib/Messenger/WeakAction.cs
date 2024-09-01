namespace NynaeveLib.Messenger
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Stores an <see cref="Action" /> without a hard reference.
    /// The owner can be garbage collected at any time.
    /// </summary>
    /// <typeparam name="T">The type of the Action's parameter.</typeparam>
    public class WeakAction<T> : IWeakAction
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="WeakAction"/> class.
        /// </summary>
        /// <param name="target">The owner of the action</param>
        /// <param name="action">The associated action</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the <paramref name="action"/> method is static.
        /// </exception>
        public WeakAction(
            object target, 
            Action<T> action)
        {
            if (action.Method.IsStatic)
            {
                throw new ArgumentException("The action cannot be static");
            }

            this.Method = action.Method;
            this.ActionReference = new WeakReference(action.Target);
            this.Reference = new WeakReference(target);

        }

        /// <summary>
        /// Gets the name of the method that this WeakAction represents.
        /// </summary>
        public string MethodName => this.Method?.Name ?? string.Empty;

        /// <summary>
        /// Gets a value indicating whether the action's owner is still alive.
        /// </summary>
        public bool IsAlive => this.Reference?.IsAlive ?? false;

        /// <summary>
        /// Gets or sets the <see cref="MethodInfo" /> corresponding to this WeakAction's
        /// method passed in the constructor.
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WeakReference"/> to the action's target.
        /// </summary>
        protected WeakReference ActionReference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="WeakReference"/> to the action's owner.
        /// </summary>
        protected WeakReference Reference { get; set; }

        /// <summary>
        /// Gets the Action's owner.
        /// </summary>
        public object Target => this.Reference?.Target == null;

        /// <summary>
        /// Gets the target of the <see cref="ActionReference"/>.
        /// </summary>
        public object ActionTarget => this.ActionReference?.Target;

        /// <summary>
        /// Executes the action.
        /// </summary>
        public void Execute()
        {
            this.Execute(default);
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="parameter">A parameter to be passed to the action.</param>
        public void Execute(T parameter)
        {
            if (!this.IsAlive)
            {
                return;
            }

            object actionTarget = this.ActionTarget;

            if (this.Method != null
                && (this.ActionReference != null)
                && actionTarget != null)
            {
                this.Method.Invoke(
                    actionTarget,
                    new object[]
                    {
                        parameter
                    });
            }
        }

        /// <summary>
        /// Executes the action with a parameter of type object. This parameter
        /// will be casted to T. This method implements <see cref="IExecuteWithObject.ExecuteWithObject" />
        /// and can be useful if you store multiple WeakAction{T} instances but don't know in advance
        /// what type T represents.
        /// </summary>
        /// <param name="parameter">The parameter that will be passed to the action after
        /// being casted to T.</param>
        public void ExecuteWithObject(object parameter)
        {
            var parameterCasted = (T)parameter;
            Execute(parameterCasted);
        }

        /// <summary>
        /// Mark the class for deletion by nulling all values.
        /// </summary>
        public void MarkForDeletion()
        {
            this.Reference = null;
            this.ActionReference = null;
            this.Method = null;
        }
    }
}
