namespace TestsMessenger
{
    using System;

    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Input arguments</param>
        static void Main(string[] args)
        {
            Sender sender = new Sender();
            Receiver recevier1 = new Receiver(1);
            Receiver recevier2 = new Receiver(2);

            Console.WriteLine("Test 1: Receive all");
            sender.RunTest();

            Console.ReadKey();
        }
    }
}
