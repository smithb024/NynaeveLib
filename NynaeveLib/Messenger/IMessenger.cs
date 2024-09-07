namespace NynaeveLib.Messenger
{
    using System;

    /// <summary>
    /// Interface for a messenger class.
    /// </summary>
    public interface IMessenger
    {
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
        void Register<TMessage>(
            object recipient,
            Action<TMessage> action);

        /// <summary>
        /// Forwards the <paramref name="message"/> to all recipients which are registered to 
        /// receive a message of it's type.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to be forwarded.</typeparam>
        /// <param name="message">
        /// The message to forward to the appropriate registered recipients.
        /// </param>
        void Send<TMessage>(TMessage message);

        /// <summary>
        /// Unregister the <paramref name="recipient"/> completely, such that it no longer 
        /// receives any messages.
        /// </summary>
        /// <param name="recipient">The recipient to be unregistered.</param>
        void Unregister(object recipient);
    }
}
