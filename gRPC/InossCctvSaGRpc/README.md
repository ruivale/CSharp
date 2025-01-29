
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

