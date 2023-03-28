using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using System.IO;



namespace MongoDBGRIDFSSample
{
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// see the example, in Java, to insert this file in the DB: D:\Projects\_generic\MongoDB\GRIDFSSample\src\pt\mongodb\gridfs\sample\GRIDFSSample.java
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class GRIDFSSample
    {
        static void Main(string[] args)
        {
            MongoServer mongoServer = MongoServer.Create("mongodb://localhost");
            MongoDatabase mongoDatabase = mongoServer.GetDatabase("test");

            MongoGridFSSettings mongoGridFSSettings = new MongoGridFSSettings(mongoDatabase);
            mongoGridFSSettings.Root = "downloads";
            Console.WriteLine("mongoGridFSSettings FilesCollName: " + mongoGridFSSettings.FilesCollectionName+
                              " ChunksCollnName: " + mongoGridFSSettings.ChunksCollectionName+
                              " Root: " + mongoGridFSSettings.Root
                              );
            MongoGridFS mongoGridFS = new MongoGridFS(mongoDatabase, mongoGridFSSettings);

            MongoCollection<BsonDocument> mongoGridFSFiles = mongoGridFS.Files;
            MongoCursor<BsonDocument> mongoCs = mongoGridFSFiles.FindAll();
            IEnumerable<BsonDocument> _iterBSonDocs = mongoCs.AsEnumerable();

            foreach (BsonDocument _bsdoc in _iterBSonDocs)
            {
                try
                {
                    //Console.WriteLine("File (elements?" + _bsdoc.ElementCount + "):");
                    //IEnumerable<BsonElement> elements = _bsdoc.Elements;
                    //foreach (BsonElement ele in elements)
                    //{
                    //    Console.WriteLine("\tBsonElement " + ele.Name + ": " + _bsdoc.GetValue(ele.Name));
                    //}
                    Console.WriteLine("FileName: " + _bsdoc.GetValue("filename") + " _id: " + _bsdoc.GetValue("_id"));
                    MongoGridFSFileInfo mongoGridFSFileInfo = mongoGridFS.FindOneById(_bsdoc.GetValue("_id"));
                    mongoGridFS.Download("c:/temp/" + _bsdoc.GetValue("filename").ToString(), mongoGridFSFileInfo);
                    Console.WriteLine("Downloaded file: " + _bsdoc.GetValue("filename").ToString());

                }
                catch(Exception e)
                {
                    Console.WriteLine("\t"+e.Message);
                }
            }
            
            Console.WriteLine();

            mongoServer.Disconnect();

            Console.ReadLine();

        }
    }

}
