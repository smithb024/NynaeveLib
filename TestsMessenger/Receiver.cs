using NynaeveLib.Messenger;
using System;

namespace TestsMessenger
{
    /// <summary>
    /// Class used to receive message via the Messenger service.
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// The id of this receiver.
        /// </summary>
        int id;

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
        /// A <see cref="PrimaryMessage"/> message has been recived from the messenger.
        /// </summary>
        /// <param name="message">The message</param>
        private void RunPrimaryMessage(PrimaryMessage message)
        {
            Console.WriteLine($"{message.Message} Received by Receiver{id}");
        }

        /// <summary>
        /// A <see cref="SecondaryMessage"/> message has been recived from the messenger.
        /// </summary>
        /// <param name="message">The message</param>
        private void RunSecondaryMessage(SecondaryMessage message)
        {
            Console.WriteLine($"{message.Message} Received by Receiver{id}");
        }
    }
}
