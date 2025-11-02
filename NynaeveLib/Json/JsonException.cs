namespace NynaeveLib.Json
{
    using System;

    /// <summary>
    /// Exception class for the Nynaeve Library XML serialiser.
    /// </summary>
    public class JsonException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="JsonException"/> class.
        /// </summary>
        /// <param name="message">message to return in the exception</param>
        /// <param name="innerException">
        /// The original serialisation attempt exception.
        /// </param>
        public JsonException(
            string message,
            Exception innerException)
        {
            this.JsonMessage = message;
            this.InnerJsonException = innerException;
        }

        /// <summary>
        /// Gets the message in the exception.
        /// </summary>
        public string JsonMessage { get; }

        /// <summary>
        /// Gets the original exception which was raised in the serialisation attempt.
        /// </summary>
        public Exception InnerJsonException { get; }
    }
}
