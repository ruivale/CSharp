
gRPC .Net 8 Console Application 
    - add nuget packages: 
        . Grpc.AspNetCore
        . Grpc.Tools;
        . Google.Protobuf 

Edit .csproj file (don't know if it's really needed):
    - add <Protobuf> tag (possible GrpcServices [defaults to Both]: Both, Server, Client, None):
        <ItemGroup>
            <Protobuf Include="Protos\XPTO.proto" GrpcServices="Both" />
        </ItemGroup>



Create a Protos folder and add a XPTO.proto file.


This client can be tested against the CCTVProxy (gRPC <-> TAO <-> CctvLegacy)


---------------------------------------------------------------------------------------------------------------------------------------------

Example

For proto defs like:

...
message VersionRequest {
    google.protobuf.Int64Value id = 1;
    google.protobuf.StringValue desc = 2;
}
message VersionRequestMsg {
    google.protobuf.Int64Value id = 1;
    repeated VersionRequest versions = 2;
}

rpc GetVersionsThroughPost(VersionRequestMsg) returns (VersionsReply){
    option (google.api.http) = {
        post: "/v1/versionsPost"
        body: "versions"
    };
}
...


After start the VS project:
        warn: Microsoft.AspNetCore.Server.Kestrel[64]
              HTTP/2 is not enabled for 127.0.0.1:5003. The endpoint is configured to use HTTP/1.1 and HTTP/2, but TLS is not enabled. HTTP/2 requires TLS application protocol negotiation. Connections to this endpoint will use HTTP/1.1.
        warn: Microsoft.AspNetCore.Server.Kestrel[64]
              HTTP/2 is not enabled for [::1]:5003. The endpoint is configured to use HTTP/1.1 and HTTP/2, but TLS is not enabled. HTTP/2 requires TLS application protocol negotiation. Connections to this endpoint will use HTTP/1.1.
        info: Microsoft.Hosting.Lifetime[14]
              Now listening on: https://localhost:7125
        info: Microsoft.Hosting.Lifetime[14]
              Now listening on: http://localhost:5003
        info: Microsoft.Hosting.Lifetime[0]
              Application started. Press Ctrl+C to shut down.
        info: Microsoft.Hosting.Lifetime[0]
              Hosting environment: Development
        info: Microsoft.Hosting.Lifetime[0]
              Content root path: C:\Users\2334\OneDrive - EFACEC Power Solutions, SGPS, SA\EFACEC\ID\Projects\GitHub\Private\ruivale\CSharp\gRPC\InossCctvSaRPC\TestInossCctvSaRPC\TestInossCctvSaRPC



Use the follwing curl cmd to test:
        curl -k http://localhost:5003/v1/versionsPost -X POST -H "Content-Type: application/json" -d '[{"id": "123","desc": "First version"}]'
        
        