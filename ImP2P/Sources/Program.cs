using System;

namespace ImP2P {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                ImServer server = new ImServer();
                server.Start();
            } else if (args.Length == 1) {
                ImClient client = new ImClient();
                client.Start(args[0]);
            } else {
                Usage();
            }
        }

        static void Usage() {
            Console.WriteLine("Usage:");
        }
    }
}
