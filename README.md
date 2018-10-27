# I'm P2P

I'm P2P is experimental implementation of IM-P2P communicator (Instant Messaging Peer to Peer). 
Main objective is to learn and test in field the newest technologies like:
- gRPC
- protobufs

Milestones for I'm P2P:
1. Client written in C#, gRPC used
2. Server written in Java, gRPC used, acts as forwarding server

# Windows build notes

## Requirements
- Visual Studio 2017 with C# SDK
- openssl (git installer for Windows contains openssl executable)

## Prepare NuGet packages
Open solution with Visual Studio 2017 and download packages via NuGet:
- Google.Protobuf
- Grpc
- Grpc.Core
- Grpc.Tools

# How to use

## Generate SSL certs
``create-certificates.bat``

## Copy SSL certs to bin directory
``copy-certs-to-bin.bat``

## Run server
``./ImP2P.exe``

## Run client 
``./ImP2P.exe server-ip``

If 127.0.0.1 or localhost doesn't work use your computer name, example:

``./ImP2P.exe "DESKTOP-URHHCEK"``

# Developer hints

## Generate gRPC definitions
``cd SOLUTION_DIR/ImP2P/Sources``

``protoc.exe -I. --csharp_out ./grpc/ --grpc_out ./grpc/ ./protos/ImP2PMessaging.proto --plugin=protoc-gen-grpc=C:\Users\[PUT YOUR USER HERE]\.nuget\packages\grpc.tools\1.16.0\tools\windows_x64\grpc_csharp_plugin.exe``

(sad story here because even if you add grpc_csharp_plugin.exe to your PATH protoc.exe cannot see it - don't know why but full path to exec solved problem)
