namespace TestsMessenger
{
    using NynaeveLib.Messenger;
    using System;

    /// <summary>
    /// Class used to receive message via the Messenger service.
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// The id of this receiver.
        /// </summary>
        readonly int id;

        /// <summary>
        /// Initialises a new instance of the <see cref="Receiver"/> class.
        /// </summary>
        /// <param name="id">Id of this class</param>
        public Receiver(int id) 
        {
            this.id = id;

            Messenger.Default.Register<PrimaryMessage>(this, this.RunPrimaryMessage);
            Messenger.Default.Register<SecondaryMessage>(this, this.RunSecondaryMessage);
        }

        /// <summary>
        /// Unregister this class from the messenger.
        /// </summary>
        public void UnRegisterMessage()
        {
            Messenger.Default.Unregister(this);
        }

        /// <summary>
        /// Register this class to receive the <see cref="PrimaryMessage"/> on the messenger.
        /// </summary>
        public void RegisterToReceivePrimaryMessage()
        {
            Messenger.Default.Register<PrimaryMessage>(this, this.RunPrimaryMessage);
        }

        /// <summary>
        /// Register this class to receive the <see cref="SecondaryMessage"/> on the messenger.
        /// </summary>
        public void RegisterToReceiveSecondaryMessage()
        {
            Messenger.Default.Register<SecondaryMessage>(this, this.RunSecondaryMessage);
        }

        /// <summary>
        /// A <see cref="PrimaryMessage"/> message has been recived from the messenger.
        /// </summary>
        /// <param name="message">The message</param>
        private void RunPrimaryMessage(PrimaryMessage message)
        {
            Console.WriteLine($"{message.Message} Received by Receiver{this.id}");
        }

        /// <summary>
        /// A <see cref="SecondaryMessage"/> message has been recived from the messenger.
        /// </summary>
        /// <param name="message">The message</param>
        private void RunSecondaryMessage(SecondaryMessage message)
        {
            Console.WriteLine($"{message.Message} Received by Receiver{this.id}");
        }
    }
}
