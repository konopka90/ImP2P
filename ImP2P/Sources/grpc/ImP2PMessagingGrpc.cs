// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/ImP2PMessaging.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ImP2PMessaging {
  public static partial class Messaging
  {
    static readonly string __ServiceName = "Messaging";

    static readonly grpc::Marshaller<global::ImP2PMessaging.ImP2PMessage> __Marshaller_ImP2PMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ImP2PMessaging.ImP2PMessage.Parser.ParseFrom);

    static readonly grpc::Method<global::ImP2PMessaging.ImP2PMessage, global::ImP2PMessaging.ImP2PMessage> __Method_SendMessage = new grpc::Method<global::ImP2PMessaging.ImP2PMessage, global::ImP2PMessaging.ImP2PMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendMessage",
        __Marshaller_ImP2PMessage,
        __Marshaller_ImP2PMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ImP2PMessaging.ImP2PMessagingReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Messaging</summary>
    public abstract partial class MessagingBase
    {
      public virtual global::System.Threading.Tasks.Task<global::ImP2PMessaging.ImP2PMessage> SendMessage(global::ImP2PMessaging.ImP2PMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Messaging</summary>
    public partial class MessagingClient : grpc::ClientBase<MessagingClient>
    {
      /// <summary>Creates a new client for Messaging</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MessagingClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Messaging that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MessagingClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MessagingClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MessagingClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::ImP2PMessaging.ImP2PMessage SendMessage(global::ImP2PMessaging.ImP2PMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendMessage(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::ImP2PMessaging.ImP2PMessage SendMessage(global::ImP2PMessaging.ImP2PMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendMessage, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::ImP2PMessaging.ImP2PMessage> SendMessageAsync(global::ImP2PMessaging.ImP2PMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendMessageAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::ImP2PMessaging.ImP2PMessage> SendMessageAsync(global::ImP2PMessaging.ImP2PMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendMessage, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MessagingClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MessagingClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MessagingBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendMessage, serviceImpl.SendMessage).Build();
    }

  }
}
#endregion
