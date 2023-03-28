using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JasonConverter");
            JasonConverter();
            Console.WriteLine("JasonParse");
            JasonParse();
            Console.WriteLine("JasonParse2DynamicObj");
            JasonParse2DynamicObj();
            Console.WriteLine("JasonSerialize");
            JasonSerialize();
        }

        private static void JasonSerialize()
        {
            string jsonData = "{ \"FirstName\":\"Jignesh\",\"LastName\":\"Trivedi\" }";
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(MyDetail));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            stream.Position = 0;
            MyDetail dataContractDetail = (MyDetail)jsonSerializer.ReadObject(stream);
            Console.WriteLine(string.Concat("Hi ", dataContractDetail.FirstName, " " + dataContractDetail.LastName));
            Console.ReadLine();
        }

        private static void JasonParse2DynamicObj()
        {
            string jsonData = @"{'FirstName':'Jignesh', 'LastName':'Trivedi' }";
            dynamic data = JObject.Parse(jsonData);

            Console.WriteLine(string.Concat("Hi ", data.FirstName, " " + data.LastName));
            Console.ReadLine();
        }

        private static void JasonParse()
        {
            string jsonData = @"{'FirstName':'Jignesh', 'LastName':'Trivedi'}";

            var details = JObject.Parse(jsonData);
            Console.WriteLine(string.Concat("Hi ", details["FirstName"], " " + details["LastName"]));

            Console.ReadLine();
        }

        private static void JasonConverter()
        {
            string jsonData = @"{'FirstName': 'Jignesh', 'LastName': 'Trivedi'} ";

            var myDetails = JsonConvert.DeserializeObject<MyDetail>(jsonData);
            Console.WriteLine(string.Concat("Hi ", myDetails.FirstName, " " + myDetails.LastName));
            Console.ReadLine();
        }

        [DataContract]
        public class MyDetail
        {
            [DataMember]
            public string FirstName
            {
                get;
                set;
            }
            [DataMember]
            public string LastName
            {
                get;
                set;
            }
        }
    }
}
