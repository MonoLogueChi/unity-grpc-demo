using Cysharp.Net.Http;
using Grpc.Net.Client;
using GrpcService0;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GrpcService0.Greeter;

public class Demo0 : MonoBehaviour
{
  [Header("Config")] [SerializeField] private string address = "http://localhost:15021/";

  [Header("UI")] [SerializeField] private TMP_InputField input;
  [SerializeField] private Button button;
  [SerializeField] private TextMeshProUGUI output;


  private GrpcChannel _channel;
  private YetAnotherHttpHandler _handler;

  private void Start()
  {
    _handler = new YetAnotherHttpHandler { Http2Only = true };
    _channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions { HttpHandler = _handler });

    button.onClick.AddListener(SayHello);
  }

  private async void SayHello()
  {
    var yourName = input.text;

    var greeter = new GreeterClient(_channel);
    var result = await greeter.SayHelloAsync(new HelloRequest { Name = yourName });

    output.text = result.Message;
  }
}