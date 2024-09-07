namespace TestsMessenger
{
    using NynaeveLib.Messenger;

    /// <summary>
    /// Class used to send message via the Messenger service.
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Sender"/> class.
        /// </summary>
        public Sender()
        { 
        }

        /// <summary>
        /// Send a couple of messages on the messenger service.
        /// </summary>
        public void RunTest()
        {
            PrimaryMessage message1 = new PrimaryMessage();
            SecondaryMessage message2 = new SecondaryMessage();

            Messenger.Default.Send(message1);
            Messenger.Default.Send(message2);
        }
    }
}
