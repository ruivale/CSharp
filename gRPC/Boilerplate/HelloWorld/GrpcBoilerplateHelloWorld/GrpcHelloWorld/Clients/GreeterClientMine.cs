
using System.Threading.Tasks;
using Grpc.Net.Client;
using Com.Efacec.ES.TRP.Efarail.Cctv.Grpc.Greeter.v1;




namespace GrpcHelloWorld.Clients
{
    /// <summary>
    /// 
    /// </summary>
    public class GreeterClientMine
    {

        private readonly string strCppgRPCServiceAddress = "172.19.181.242";

        //private readonly string strJavagRPCServiceAddress = "172.25.240.1";
        //private readonly string strJavagRPCServiceAddress = "172.18.64.77";
        private readonly string strJavagRPCServiceAddress = "172.31.0.1";
    

        /// <summary>
        /// 
        /// </summary>
        public GreeterClientMine()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void SayHelloCpp()
        {

            try
            {
                // The port number must match the port of the gRPC server.
                using var channel = GrpcChannel.ForAddress("http://"+ strCppgRPCServiceAddress + ":50051");


                var client = new Greeter.GreeterClient(channel);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var reply = client.SayHello(new HelloRequest { Name = "GreeterClient from C#! ;-) " });
                //var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient from C#! ;-) " });

                stopwatch.Stop();

                Console.WriteLine("Greeting: " + reply.Message+". It took "+ stopwatch.ElapsedMilliseconds + " millis");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Hello - Exception: \n" + exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SayGoodbyeCpp()
        {
            try
            {
                // The port number must match the port of the gRPC server.
                using var channel = GrpcChannel.ForAddress("http://" + strCppgRPCServiceAddress + ":50051");


                var client = new Greeter.GreeterClient(channel);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var reply = client.SayGoodbye(new EmptyRequest());

                stopwatch.Stop();

                Console.WriteLine("Goodbye: " + reply.Message + ". It took " + stopwatch.ElapsedMilliseconds + " millis");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Goodbye - Exception: \n" + exc.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SayHelloJava()
        {

            try
            {
                // The port number must match the port of the gRPC server.
                using var channel = GrpcChannel.ForAddress("http://" + strJavagRPCServiceAddress + ":50051");


                var client = new Greeter.GreeterClient(channel);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var reply = client.SayHello(new HelloRequest { Name = "GreeterClient from C#! ;-) " });
                //var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient from C#! ;-) " });

                stopwatch.Stop();

                Console.WriteLine("Greeting: " + reply.Message + ". It took " + stopwatch.ElapsedMilliseconds + " millis");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Hello - Exception: \n" + exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SayGoodbyeJava()
        {
            try
            {
                // The port number must match the port of the gRPC server.
                using var channel = GrpcChannel.ForAddress("http://" + strJavagRPCServiceAddress + ":50051");


                var client = new Greeter.GreeterClient(channel);

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                var reply = client.SayGoodbye(new EmptyRequest());

                stopwatch.Stop();

                Console.WriteLine("Goodbye: " + reply.Message + ". It took " + stopwatch.ElapsedMilliseconds + " millis");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Goodbye - Exception: \n" + exc.ToString());
            }
        }
    }
}
