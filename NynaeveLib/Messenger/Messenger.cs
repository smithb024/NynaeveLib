namespace NynaeveLib.Messenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Threading;

    /// <summary>
    /// Service which allows classes to loosly exchange messages.
    /// This employs the singleton pattern.
    /// </summary>
    public class Messenger : IMessenger
    {
        /// <summary>
        /// Lock object used to prevent multiple instances from being created.
        /// </summary>
        private static readonly object CreationLock = new object();

        /// <summary>
        /// The instance of theis class.
        /// </summary>
        private static IMessenger instance;

        /// <summary>
        /// Lock used to manage access to the manager.
        /// </summary>
        private readonly object registerLock = new object();

        /// <summary>
        /// Dictionary containing all registered messages and methods to run when the message is 
        /// passed to the messenger.
        /// </summary>
        private Dictionary<Type, List<IWeakAction>> registeredMessages;

        /// <summary>
        /// Indicates that a clean up of the registered messages has been requested. 
        /// </summary>
        private bool isCleanupRegistered;

        /// <summary>
        /// Gets the default instance of the messenger.
        /// </summary>
        public static IMessenger Default
        {
            get
            {
                if (instance == null)
                {
                    lock (CreationLock)
                    {
                        if (instance == null)
                        {
                            instance = new Messenger();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Registers a <paramref name="recipient"/> to receive <typeparamref name="TMessage"/>
        /// message from the messenger.
        /// </summary>
        /// <typeparam name="TMessage">
        /// The type of message that the <paramref name="recipient"/> registers for.
        /// </typeparam>
        /// <param name="recipient">
        /// The recipient that will receive the messages. No hard reference is created for this.
        /// </param>
        public void Register<TMessage>(
            object recipient,
            Action<TMessage> action)
        {
            lock (this.registerLock)
            {
                if (this.registeredMessages != null)
                {
                    foreach (KeyValuePair<Type, List<IWeakAction>> dictEntry in this.registeredMessages)
                    {
                        foreach (IWeakAction dictAction in dictEntry.Value)
                        {
                            if (dictAction.ActionTarget == recipient &&
                                dictAction.Method == action.Method &&
                                dictAction.IsAlive)
                            {
                                return;
                            }
                        }
                    }
                }

                Type messageType = typeof(TMessage);

                Dictionary<Type, List<IWeakAction>> recipients;

                if (this.registeredMessages == null)
                {
                    this.registeredMessages = new Dictionary<Type, List<IWeakAction>>();
                }

                recipients = this.registeredMessages;

                lock (recipients)
                {
                    List<IWeakAction> list;

                    if (!recipients.ContainsKey(messageType))
                    {
                        list = new List<IWeakAction>();
                        recipients.Add(messageType, list);
                    }
                    else
                    {
                        list = recipients[messageType];
                    }

                    WeakAction<TMessage> weakAction = new WeakAction<TMessage>(recipient, action);

                    list.Add(weakAction);
                }
            }

            this.RequestCleanup();
        }

        /// <summary>
        /// Forwards the <paramref name="message"/> to all recipients which are registered to 
        /// receive a message of it's type.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to be forwarded.</typeparam>
        /// <param name="message">
        /// The message to forward to the appropriate registered recipients.
        /// </param>
        public void Send<TMessage>(TMessage message)
        {
            if (this.registeredMessages == null)
            {
                return;
            }

            Type messageType = typeof(TMessage);

            lock (this.registeredMessages)
            {
                if (this.registeredMessages.ContainsKey(messageType))
                {
                    List<IWeakAction> list =
                        this.registeredMessages[messageType]
                        .Take(this.registeredMessages[messageType].Count())
                        .ToList();
                    DistributeMessage(message, list);
                }
            }

            this.RequestCleanup();
        }

        /// <summary>
        /// Unregister the <paramref name="recipient"/> completely, such that it no longer 
        /// receives any messages.
        /// </summary>
        /// <param name="recipient">The recipient to be unregistered.</param>
        public virtual void Unregister(object recipient)
        {
            UnregisterFromLists(recipient, this.registeredMessages);
            this.RequestCleanup();
        }

        /// <summary>
        /// Tidy up the <paramref name="lists"/> to remove all the actions which are not alive.
        /// </summary>
        /// <param name="lists">The list to tidy</param>
        private static void CleanupList(
            IDictionary<Type, List<IWeakAction>> lists)
        {
            if (lists == null)
            {
                return;
            }

            lock (lists)
            {
                List<Type> listsToRemove = new List<Type>();

                foreach (KeyValuePair<Type, List<IWeakAction>> list in lists)
                {
                    List<IWeakAction> recipientsToRemove = 
                        list
                        .Value
                        .Where(action => action == null || !action.IsAlive)
                        .ToList();

                    foreach (IWeakAction recipient in recipientsToRemove)
                    {
                        list.Value.Remove(recipient);
                    }

                    if (list.Value.Count == 0)
                    {
                        listsToRemove.Add(list.Key);
                    }
                }

                foreach (Type key in listsToRemove)
                {
                    lists.Remove(key);
                }
            }
        }

        /// <summary>
        /// Send the <paramref name="message"/> to all classes which have registered to receive it.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to send.</typeparam>
        /// <param name="message">The message to send.</param>
        /// <param name="weakActions">
        /// The collection of actions which are used to send the message.
        /// </param>
        private static void DistributeMessage<TMessage>(
            TMessage message,
            IEnumerable<IWeakAction> weakActions)
        {
            if (weakActions == null)
            {
                return;
            }

            List<IWeakAction> list = weakActions.ToList();
            List<IWeakAction> listClone = list.Take(list.Count()).ToList();

            foreach (IWeakAction action in listClone)
            {
                if (action is IWeakAction executeAction
                    && action.IsAlive
                    && action.Target != null)
                {
                    executeAction.ExecuteWithObject(message);
                }
            }
        }

        /// <summary>
        /// Unregister the <paramref name="recipient"/> from all lists.
        /// </summary>
        /// <param name="recipient">The class to unregister</param>
        /// <param name="lists">The lists of registered classes and messages.</param>
        private static void UnregisterFromLists(
            object recipient, 
            Dictionary<Type, List<IWeakAction>> lists)
        {
            if (recipient == null
                || lists == null
                || lists.Count == 0)
            {
                return;
            }

            lock (lists)
            {
                foreach (Type messageType in lists.Keys)
                {
                    foreach (IWeakAction action in lists[messageType])
                    {
                        IWeakAction weakAction = action;

                        if (weakAction != null
                            && recipient == weakAction.ActionTarget)
                        {
                            weakAction.MarkForDeletion();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Notifies the Messenger that the lists of recipients should
        /// be scanned and cleaned up.
        /// Since recipients are stored as <see cref="WeakReference"/>, 
        /// recipients can be garbage collected even though the Messenger keeps 
        /// them in a list. During the cleanup operation, all "dead"
        /// recipients are removed from the lists. Since this operation
        /// can take a moment, it is only executed when the application is
        /// idle. For this reason, a user of the Messenger class should use
        /// <see cref="RequestCleanup"/> instead of forcing one with the 
        /// <see cref="Cleanup" /> method.
        /// </summary>
        public void RequestCleanup()
        {
            if (!isCleanupRegistered)
            {
                Action cleanupAction = this.Cleanup;

                Dispatcher.CurrentDispatcher.BeginInvoke(
                    cleanupAction,
                    DispatcherPriority.ApplicationIdle,
                    null);
                this.isCleanupRegistered = true;
            }
        }

        /// <summary>
        /// Scans the recipients' lists for "dead" instances and removes them.
        /// Since recipients are stored as <see cref="WeakReference"/>, 
        /// recipients can be garbage collected even though the Messenger keeps 
        /// them in a list. During the cleanup operation, all "dead"
        /// recipients are removed from the lists. Since this operation
        /// can take a moment, it is only executed when the application is
        /// idle. For this reason, a user of the Messenger class should use
        /// <see cref="RequestCleanup"/> instead of forcing one with the 
        /// <see cref="Cleanup" /> method.
        /// </summary>
        public void Cleanup()
        {
            CleanupList(this.registeredMessages);
            this.isCleanupRegistered = false;
        }
    }
}
