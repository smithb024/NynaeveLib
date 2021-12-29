namespace NynaeveLib.XML
{
    using System;

    /// <summary>
    /// Exception class for the Nynaeve Library XML serialiser.
    /// </summary>
    public class XmlException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="XmlException"/> class.
        /// </summary>
        /// <param name="message">message to return in the exception</param>
        /// <param name="innerException">
        /// The original serialisation attempt exception.
        /// </param>
        public XmlException(
            string message,
            Exception innerException)
        {
            this.XmlMessage = message;
            this.InnerXmlException = innerException;
        }

        /// <summary>
        /// Gets the message in the exception.
        /// </summary>
        public string XmlMessage { get; }

        /// <summary>
        /// Gets the original exception which was raised in the serialisation attempt.
        /// </summary>
        public Exception InnerXmlException { get; }
    }
}