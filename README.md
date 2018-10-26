# I'm P2P

I'm P2P is experimental implementation of IM-P2P communicator (Instant Messaging Peer to Peer). 
Main objective is to learn and test in field the newest technologies like:
- gRPC
- protobufs

Milestones for I'm P2P:
1. Client written in C#, gRPC used
2. Server written in Java, gRPC used, acts as forwarding server

# Windows build notes

## Prepare NuGet packages
Open solution with Visual Studio 2017 and download packages via NuGet:
- Google.Protobuf
- Grpc
- Grpc.Core
- Grpc.Tools

## Generate gRPC definitions
``cd SOLUTION_DIR/ImP2P/Sources``

``protoc.exe -I. --csharp_out ./grpc/ --grpc_out ./grpc/ ./protos/ImP2PMessaging.proto --plugin=protoc-gen-grpc=C:\Users\[PUT YOUR USER HERE]\.nuget\packages\grpc.tools\1.16.0\tools\windows_x64\grpc_csharp_plugin.exe``

(sad story here because even if you add grpc_csharp_plugin.exe to your PATH protoc.exe cannot see it - don't know why but full path to exec solved problem)
