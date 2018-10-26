namespace ImP2P {
    class Program {
        static void Main(string[] args) {
            if (args.Length > 0) {
                ImClient client = new ImClient();
                client.Start(args[0]);
            } else {
                ImServer server = new ImServer();
                server.Start();
            }
        }
    }
}
