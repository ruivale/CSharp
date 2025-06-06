using Google.Api;
using Microsoft.OpenApi.Models;
using Microsoft.Win32;
using Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.Services;
using Microsoft.AspNetCore.Grpc.JsonTranscoding;


var builder = WebApplication.CreateBuilder(args);


// Register transcoding in server startup code by adding AddJsonTranscoding:
//  - In the Program.cs file, change builder.Services.AddGrpc();
//    to builder.Services.AddGrpc().AddJsonTranscoding();.
// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();



// Then, before we build the app variable from the builder variable,
// we add the following lines to import all Swagger dependencies:
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CCTV Service test API", Version = "v1" });
});


var app = builder.Build();


// Finally, we will add the following lines just after the app variable
// initialization to add Swagger endpoints to the middleware:
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CCTV Service test API V1");
});


app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });


// Specifies that the endpoints.MapGrpcService<CctvServiceTests>()
//app.MapGrpcService<CctvServiceTests>().EnableGrpcWeb();
// Specifies that the endpoints.MapGrpcService<CctvService>()
app.MapGrpcService<Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Operation.Services.CctvOperationServerImpl>().EnableGrpcWeb();


app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();


