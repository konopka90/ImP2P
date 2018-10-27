using Grpc.Core;
using ImP2PMessaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ImP2P {
    class ImServer {
        const string ServerId = "NODE_001";
        const string Host = "0.0.0.0";

        private class ImP2PMessagingServer : ImP2PMessaging.Messaging.MessagingBase {
            public override Task<ImP2PMessage> SendMessage(ImP2PMessage request, ServerCallContext context) {
                Console.WriteLine("[" + ServerId + "] " + "{" + request.Name + "} : {" + request.Msg + "}");
                return Task.FromResult(new ImP2PMessage { Name = ServerId, Msg = "Welcome " + request.Name });
            }
        }

        public void Start() {
            var cacert = File.ReadAllText(@"certs/ca.crt");
            var servercert = File.ReadAllText(@"certs/server.crt");
            var serverkey = File.ReadAllText(@"certs/server.key");
            var keypair = new KeyCertificatePair(servercert, serverkey);
            var sslCredentials = new SslServerCredentials(new List<KeyCertificatePair>() { keypair }, cacert, false);

            Server server = new Server {
                Services = { ImP2PMessaging.Messaging.BindService(new ImP2PMessagingServer()) },
                Ports = { new ServerPort(Host, Constants.Port, sslCredentials) }
            };

            server.Start();

            Console.WriteLine("Server listening on port " + Constants.Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
