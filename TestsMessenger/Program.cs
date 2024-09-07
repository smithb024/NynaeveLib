namespace TestsMessenger
{
    using System;

    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method, run tests.
        /// </summary>
        /// <param name="args">Input arguments, not used</param>
        static void Main(string[] args)
        {
            Sender sender = new Sender();
            Receiver recevier1 = new Receiver(1);
            Receiver recevier2 = new Receiver(2);

            Console.WriteLine("Test 1: Receive all");
            sender.RunTest();

            Console.WriteLine();
            Console.WriteLine("Test 2: Stop receiver 2 from receiving messages");
            recevier2.UnRegisterMessage();
            sender.RunTest();

            Console.WriteLine();
            Console.WriteLine("Test 3: Reregister receiver 2 to receive secondary messages");
            recevier2.RegisterToReceiveSecondaryMessage();
            sender.RunTest();

            Console.WriteLine();
            Console.WriteLine("Test 4: Reregister receiver 2 to receive secondary messages again");
            recevier2.RegisterToReceiveSecondaryMessage();
            sender.RunTest();

            Console.WriteLine();
            Console.WriteLine("Test 5: Unregister all");
            recevier1.UnRegisterMessage();
            recevier2.UnRegisterMessage();
            sender.RunTest();

            Console.ReadKey();
        }
    }
}
