using GrpcHelloWorld.Clients;
using GrpcHelloWorld.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddGrpc();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
//app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//app.Run();



GreeterClientMine gCli = new GreeterClientMine();
Console.WriteLine("\n\nFrom the C++ service...");
gCli.SayHelloCpp();
gCli.SayGoodbyeCpp();

Console.WriteLine("\n\nFrom the Java service...");
gCli.SayHelloJava();
gCli.SayGoodbyeJava();

Console.WriteLine("\n\n\n\nPress any key to exit...");
Console.ReadKey();


