This is a DEMO of Unity using GRPC

## how to use

### install software

- visual studio 2022 with .net7
- unity3d 2022.3.6f1 with il2cpp

### clone

```
git clone --recurse-submodules https://github.com/MonoLogueChi/unity-grpc-demo.git
```

### config

Edit -> Preferences -> Protobuf

copy the path of grpc.tools, example:

```
D:\Users\mc\Documents\Unity\unity-grpc-demo\client\grpc.tools.2.56.2\tools\windows_x64\protoc.exe


D:\Users\mc\Documents\Unity\unity-grpc-demo\client\grpc.tools.2.56.2\tools\windows_x64\grpc_csharp_plugin.exe
```

## about package

- [YetAnotherHttpHandler](https://github.com/Cysharp/YetAnotherHttpHandler) YetAnotherHttpHandler brings the power of HTTP/2 (and gRPC) to Unity and .NET Standard.
- [protobuf-unity](https://github.com/5argon/protobuf-unity) Automatic .proto files compilation in Unity project to C# as you edit them, plus utilities.
- [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/) C# runtime library for Protocol Buffers - Google's data interchange format.
- [Grpc.AspNetCore](https://www.nuget.org/packages/Grpc.AspNetCore/)
- ...
