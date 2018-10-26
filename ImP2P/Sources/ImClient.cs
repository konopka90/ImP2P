using System;
using Grpc.Core;

namespace ImP2P {
    class ImClient {
        const string message = "Hello!";

        public void Start(string name) {
            Channel channel = new Channel(Constants.Host + ": " + Constants.Port, ChannelCredentials.Insecure);
            var client = new ImP2PMessaging.Messaging.MessagingClient(channel);

            Console.WriteLine("Sending message:" + message);
            var reply = client.SendMessage(new ImP2PMessaging.ImP2PMessage { Name = name, Msg = message });
            Console.WriteLine("Server " + reply.Name + " replied with " + reply.Msg);

            channel.ShutdownAsync().Wait();
        }
    }
}
