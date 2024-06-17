using Test.Com.Efacec.ES.Efarail.Cctv.Grpc.Operation.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();


//// To allow a browser app to make cross-origin gRPC-Web calls, set up CORS in ASP.NET Core.
//// Use the built-in CORS support, and expose gRPC-specific headers with WithExposedHeaders.
////
//// Calls AddCors to add CORS services and configure a CORS policy that exposes gRPC-specific headers.
//builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
//{
//    builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
//}));




var app = builder.Build();


app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });


//// Calls UseCors to add the CORS middleware after routing configuration and before endpoints configuration.
//app.UseCors();


// Specifies that the endpoints.MapGrpcService<GreeterService>() method supports CORS with RequireCors.
app.MapGrpcService<CctvServiceTests>().EnableGrpcWeb();
//app.MapGrpcService<CctvServiceTests>().EnableGrpcWeb().RequireCors("AllowAll");


// original
// Configure the HTTP request pipeline.
//app.MapGrpcService<CctvServiceTests>();


app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();


