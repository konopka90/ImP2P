using Grpc.Core;
using ImP2PMessaging;
using System;
using System.Threading.Tasks;

namespace ImP2P {
    class ImServer {
        const string ServerId = "NODE_001";

        private class ImP2PMessagingServer : ImP2PMessaging.Messaging.MessagingBase {
            public override Task<ImP2PMessage> SendMessage(ImP2PMessage request, ServerCallContext context) {
                Console.WriteLine("[" + ServerId + "] " + "{" + request.Name + "} : {" + request.Msg + "}");
                return Task.FromResult(new ImP2PMessage { Name = ServerId, Msg = "Welcome " + request.Name });
            }
        }

        public void Start() {
            Server server = new Server {
                Services = { ImP2PMessaging.Messaging.BindService(new ImP2PMessagingServer()) },
                Ports = { new ServerPort(Constants.Host, Constants.Port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("Server listening on port " + Constants.Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
