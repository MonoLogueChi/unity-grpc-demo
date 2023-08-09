using Cysharp.Net.Http;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService0;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GrpcService0.Greeter;

public class Demo1 : MonoBehaviour
{
  [Header("Config")] [SerializeField] private string address = "http://localhost:15021/";

  [Header("UI")] [SerializeField] private TMP_InputField input;
  [SerializeField] private Button button;
  [SerializeField] private TextMeshProUGUI output;

  private AsyncDuplexStreamingCall<HelloRequest, HelloReply> _call;
  private GrpcChannel _channel;
  private GreeterClient _greeter;
  private YetAnotherHttpHandler _handler;

  private async void Start()
  {
    _handler = new YetAnotherHttpHandler { Http2Only = true };
    _channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions { HttpHandler = _handler });
    _greeter = new GreeterClient(_channel);
    _call = _greeter.SayHello1();

    button.onClick.AddListener(SayHello);

    await foreach (var response in _call.ResponseStream.ReadAllAsync()) output.text = response.Message;
  }


  private async void SayHello()
  {
    var yourName = input.text;

    await _call.RequestStream.WriteAsync(new HelloRequest { Name = yourName });
  }
}