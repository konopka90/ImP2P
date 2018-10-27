using System;
using System.IO;
using Grpc.Core;

namespace ImP2P {
    class ImClient {
        const string Name = "TestUser";
        const string Message = "Hello!";

        public void Start(String destinationHost) {
            var cacert = File.ReadAllText(@"certs/ca.crt");
            var clientcert = File.ReadAllText(@"certs/client.crt");
            var clientkey = File.ReadAllText(@"certs/client.key");
            var ssl = new SslCredentials(cacert, new KeyCertificatePair(clientcert, clientkey));

            Channel channel = new Channel(destinationHost + ":" + Constants.Port, ssl);
            var client = new ImP2PMessaging.Messaging.MessagingClient(channel);

            Console.WriteLine("Sending message:" + Message);
            var reply = client.SendMessage(new ImP2PMessaging.ImP2PMessage { Name = Name, Msg = Message });
            Console.WriteLine("Server " + reply.Name + " replied with " + reply.Msg);

            channel.ShutdownAsync().Wait();
        }
    }
}
