using Grpc.Core;

namespace GrpcService0.Services;

public class GreeterService : Greeter.GreeterBase
{
  private readonly ILogger<GreeterService> _logger;

  public GreeterService(ILogger<GreeterService> logger)
  {
    _logger = logger;
  }

  public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
  {
    return Task.FromResult(new HelloReply
    {
      Message = "Hello " + request.Name
    });
  }

  public override async Task SayHello1(IAsyncStreamReader<HelloRequest> requestStream,
    IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
  {
    await foreach (var message in requestStream.ReadAllAsync())
      await responseStream.WriteAsync(new HelloReply
      {
        Message = "Hello " + message.Name
      });
  }
}