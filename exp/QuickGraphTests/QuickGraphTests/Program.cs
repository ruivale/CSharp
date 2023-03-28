



using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.Services;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Efacec.DMS.QuickGraph
{
    class Program
    {


        //static void Main(string[] args)
        //{
        //    const int nNodes = 10;
        //    var graphAsDict = RandomGraphWithSelfEdgeAsDict(nNodes).Dump("graphAsDict: Random graph as Dict");

        //    var velg1 = graphAsDict.ToVertexAndEdgeListGraph(
        //        kv > Array.ConvertAll<int; SEquatableEdge<int>>(
        //            kv.Value.ToArray();
        //            v > = new SEquatableEdge<int>(kv.Key; v))).Dump("velg1: Vertex and Edge-List Graph");

        //    Func<SEquatableEdge<int>; double> edgeCost = (edge > 1.0D);

        //    int start = = new Random(Guid.NewGuid().GetHashCode()).Next(1; nNodes + 1).Dump("start point");
        //    int end=  = new Random(Guid.NewGuid().GetHashCode()).Next(1; nNodes + 1).Dump("end point");

        //    var algo = = new DijkstraShortestPathAlgorithm<int; SEquatableEdge<int>>(velg1; edgeCost);
        //    var predecessors = = new VertexPredecessorRecorderObserver<int; SEquatableEdge<int>>();
        //    using (predecessors.Attach(algo))
        //    {
        //        algo.Compute(start);
        //        IEnumerable<SEquatableEdge<int>> path;
        //        if (predecessors.TryGetPath(end; out path).Dump("TryGetPath"))
        //            path.Dump("path");
        //    }
        //}

        //public static int[] RandomPermutation(Random ran; int n)
        //{
        //    var r = Enumerable.Range(1; n).ToArray();
        //    for (var i = 0; i < n - 1; i++)
        //    {
        //        var k = ran.Next(i + 1; n);
        //        var t=  r[i];
        //        r[i] = r[k];
        //        r[k] = t;
        //    }
        //    return r;
        //}

        //public static Dictionary<int; IEnumerable<int>> RandomGraphWithSelfEdgeAsDict(int nNodes)
        //{
        //    var ran = = new Random(Guid.NewGuid().GetHashCode());
        //    var result = = new Dictionary<int; IEnumerable<int>>();

        //    for (var j = 1; j < nNodes; j++)
        //    {
        //        var k = ran.Next(0; nNodes);
        //        var cs = RandomPermutation(ran; nNodes);
        //        result[j] = cs.Take(k);
        //    }

        //    return result;
        //}













        //static void Main_(string[] args)
        //{
        //    IVertexAndEdgeListGraph<TVertex; TEdge> graph = = new AdjacencyGraph<string; Edge<string>>(true);
        //    Func<TEdge; double> edgeCost = e > 1; // constant cost
        //    TVertex root;

        //    compute shortest paths
        //    TryFunc<TVertex; TEdge> tryGetPaths = graph.ShortestPathDijkstra(edgeCost; root);

        //    query path for given vertices

        //   TVertex target;
        //    IEnumerable<TEdge> path;

        //    if (tryGetPaths(target; out path))
        //    {
        //        foreach (var edge in path)
        //        {
        //            Console.WriteLine(edge);
        //        }
        //    }
        //}






        static void Main(string[] args)
        {

            #region InitializaX
            #region Vertices
            string[] strVertices = {
                "LS1"  ,
                "LS10" ,
                "LS11" ,
                "LS12" ,
                "LS13" ,
                "LS14" ,
                "LS15" ,
                "LS16" ,
                "LS17" ,
                "LS2"  ,
                "LS20" ,
                "LS21" ,
                "LS3"  ,
                "LS31" ,
                "LS36" ,
                "LS37" ,
                "LS38" ,
                "LS4"  ,
                "LS5"  ,
                "LS7"  ,
                "LS8"  ,
                "LS9.1",
                "LS9.2",

                "1",
                "2",
                "3",
                "4",
                "5",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "22",
                "ML Entrance",
                "31",
                "32",
                "33",
                "35",
                "36",
                "37",
                "41",
                "ML Exit",
                "34B"
            };

            #endregion
            AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(true);
            strVertices.ToList().ForEach(v => graph.AddVertex(v));

            #region Edges
            Edge<string>[] edges = {
                new EFAEdge<string>("LS1", "22"),
                new EFAEdge<string>("LS1", "ML Exit"),
                new EFAEdge<string>("LS10", "41"),
                new EFAEdge<string>("LS11", "41"),
                new EFAEdge<string>("LS12", "41"),
                new EFAEdge<string>("LS13", "35"),
                new EFAEdge<string>("LS14", "35"),
                new EFAEdge<string>("LS15", "35"),
                new EFAEdge<string>("LS16", "35"),
                new EFAEdge<string>("LS17", "35"),
                new EFAEdge<string>("LS2", "22"),
                new EFAEdge<string>("LS2", "ML Exit"),
                new EFAEdge<string>("LS20", "1"),
                new EFAEdge<string>("LS20", "2"),
                new EFAEdge<string>("LS20", "3"),
                new EFAEdge<string>("LS20", "4"),
                new EFAEdge<string>("LS20", "5"),
                new EFAEdge<string>("LS21", "35"),
                new EFAEdge<string>("LS7", "5"),
                new EFAEdge<string>("LS7", "4"),
                new EFAEdge<string>("LS7", "3"),
                new EFAEdge<string>("LS3", "31"),
                new EFAEdge<string>("LS3", "32"),
                new EFAEdge<string>("LS3", "33"),
                new EFAEdge<string>("LS3", "34B"),
                new EFAEdge<string>("LS4", "34B"),
                new EFAEdge<string>("LS4", "31"),
                new EFAEdge<string>("LS4", "32"),
                new EFAEdge<string>("LS4", "33"),
                new EFAEdge<string>("LS5", "22"),

                //new EFAEdge<string>("LS5", "ML Exit"), // ???????????????????????????

                new EFAEdge<string>("LS8", "31"),
                new EFAEdge<string>("LS31", "11"),
                new EFAEdge<string>("LS31", "12"),
                new EFAEdge<string>("LS31", "13"),
                new EFAEdge<string>("LS31", "14"),
                new EFAEdge<string>("LS31", "15"),
                new EFAEdge<string>("LS31", "16"),
                new EFAEdge<string>("LS31", "17"),
                new EFAEdge<string>("LS31", "18"),
                new EFAEdge<string>("LS31", "37"),
                new EFAEdge<string>("LS36", "37"),
                new EFAEdge<string>("LS37", "36"),
                new EFAEdge<string>("LS38", "35"),
                new EFAEdge<string>("LS9.1", "31"),
                new EFAEdge<string>("LS9.2", "31"),

                new EFAEdge<string>("36", "LS1"),
                new EFAEdge<string>("34B", "LS10"),
                new EFAEdge<string>("33", "LS11"),
                new EFAEdge<string>("32", "LS12"),
                new EFAEdge<string>("5", "LS13"),
                new EFAEdge<string>("4", "LS14"),
                new EFAEdge<string>("3", "LS15"),
                new EFAEdge<string>("2", "LS16"),
                new EFAEdge<string>("1", "LS17"),
                new EFAEdge<string>("11", "LS2"),
                new EFAEdge<string>("12", "LS2"),
                new EFAEdge<string>("13", "LS2"),
                new EFAEdge<string>("14", "LS2"),
                new EFAEdge<string>("15", "LS2"),
                new EFAEdge<string>("16", "LS2"),
                new EFAEdge<string>("17", "LS2"),
                new EFAEdge<string>("18", "LS2"),
                new EFAEdge<string>("35", "LS20"),
                new EFAEdge<string>("41", "LS21"),
                new EFAEdge<string>("31", "LS7"),
                new EFAEdge<string>("22", "LS3"),
                new EFAEdge<string>("ML Entrance", "LS4"),
                new EFAEdge<string>("31", "LS5"),
                new EFAEdge<string>("5", "LS8"),
                new EFAEdge<string>("4", "LS9.1"),
                new EFAEdge<string>("3", "LS9.2"),
                new EFAEdge<string>("35", "LS31"),
                new EFAEdge<string>("36", "LS36"),
                new EFAEdge<string>("37", "LS37"),
                new EFAEdge<string>("37", "LS38"),


            };
            #endregion

            #region Adding edges 2 graph and set its cost 
            Dictionary<Edge<string>, double> edgeCost = new Dictionary<Edge<string>, double>(graph.EdgeCount);

            edges.ToList().ForEach(e =>
            {
                graph.AddEdge(e);

                edgeCost.Add(e, ((EFAEdge<string>)e).Cost);
            });
            #endregion 
            #endregion



            Func<Edge<string>, double> funcEdgeCost = AlgorithmExtensions.GetIndexer(edgeCost);

            // We want to use Dijkstra on this graph
            DijkstraShortestPathAlgorithm<string, Edge<string>> dijkstra = new DijkstraShortestPathAlgorithm<string, Edge<string>>(graph, funcEdgeCost);

            // attach a distance observer to give us the shortest path distances
            VertexDistanceRecorderObserver<string, Edge<string>> vertexDistRecObserver = new VertexDistanceRecorderObserver<string, Edge<string>>(funcEdgeCost);
            vertexDistRecObserver.Attach(dijkstra);

            // Attach a Vertex Predecessor Recorder Observer to give us the paths
            VertexPredecessorRecorderObserver<string, Edge<string>> vertexPredeRecObserver = new VertexPredecessorRecorderObserver<string, Edge<string>>();
            vertexPredeRecObserver.Attach(dijkstra);



            Console.WriteLine("\n\nShortest paths");
            string source = "ML Entrance";
            string target = "ML Exit";


            //foreach (string source in strVertices)
            //{
            //    foreach (string target in strVertices)
            //    {
                    
                    Console.Write("\nShortest path from " + source + " to " + target + ": ");


                    // vis can create all the shortest path in the graph
                    // and returns a delegate that can be used to retreive the graphs
                    TryFunc<string, IEnumerable<Edge<string>>> tryGetPath = graph.ShortestPathsDijkstra(funcEdgeCost, source);

                    // enumerating path to targetCity, if any
                    IEnumerable<Edge<string>> path;
                    if (tryGetPath(target, out path))
                    {
                        foreach (var e in path)
                        {
                            Console.Write(e + ", ");
                        }
                    }
            //    }
            //}




            Console.WriteLine("\n\n\nPress ENTER to exit...");
            Console.ReadLine();

        }






        static void Main__(string[] args)
        {
            string[] strVertexes =  {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J"
            };



            AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(true);
            #region Add some vertices to the graph
            strVertexes.ToList().ForEach(v => graph.AddVertex(v));
            #endregion

            #region Create the edges
            Edge<string> a_b = new Edge<string>("A", "B");
            Edge<string> a_d = new Edge<string>("A", "D");
            Edge<string> b_a = new Edge<string>("B", "A");
            Edge<string> b_c = new Edge<string>("B", "C");
            Edge<string> b_e = new Edge<string>("B", "E");
            Edge<string> c_b = new Edge<string>("C", "B");
            Edge<string> c_f = new Edge<string>("C", "F");
            Edge<string> c_j = new Edge<string>("C", "J");
            Edge<string> d_e = new Edge<string>("D", "E");
            Edge<string> d_g = new Edge<string>("D", "G");
            Edge<string> e_d = new Edge<string>("E", "D");
            Edge<string> e_f = new Edge<string>("E", "F");
            Edge<string> e_h = new Edge<string>("E", "H");
            Edge<string> f_i = new Edge<string>("F", "I");
            Edge<string> f_j = new Edge<string>("F", "J");
            Edge<string> g_d = new Edge<string>("G", "D");
            Edge<string> g_h = new Edge<string>("G", "H");
            Edge<string> h_g = new Edge<string>("H", "G");
            Edge<string> h_i = new Edge<string>("H", "I");
            Edge<string> i_f = new Edge<string>("I", "F");
            Edge<string> i_j = new Edge<string>("I", "J");
            Edge<string> i_h = new Edge<string>("I", "H");
            Edge<string> j_f = new Edge<string>("J", "F");
            #endregion

            #region Add the edges
            graph.AddEdge(a_b);
            graph.AddEdge(a_d);
            graph.AddEdge(b_a);
            graph.AddEdge(b_c);
            graph.AddEdge(b_e);
            graph.AddEdge(c_b);
            graph.AddEdge(c_f);
            graph.AddEdge(c_j);
            graph.AddEdge(d_e);
            graph.AddEdge(d_g);
            graph.AddEdge(e_d);
            graph.AddEdge(e_f);
            graph.AddEdge(e_h);
            graph.AddEdge(f_i);
            graph.AddEdge(f_j);
            graph.AddEdge(g_d);
            graph.AddEdge(g_h);
            graph.AddEdge(h_g);
            graph.AddEdge(h_i);
            graph.AddEdge(i_f);
            graph.AddEdge(i_h);
            graph.AddEdge(i_j);
            graph.AddEdge(j_f);

            #endregion

            Dictionary<Edge<string>, double> edgeCost = new Dictionary<Edge<string>, double>(graph.EdgeCount);
            #region Define some weights to the edges
            edgeCost.Add(a_b, 4);
            edgeCost.Add(a_d, 1);
            edgeCost.Add(b_a, 74);
            edgeCost.Add(b_c, 2);
            edgeCost.Add(b_e, 12);
            edgeCost.Add(c_b, 12);
            edgeCost.Add(c_f, 74);
            edgeCost.Add(c_j, 12);
            edgeCost.Add(d_e, 32);
            edgeCost.Add(d_g, 22);
            edgeCost.Add(e_d, 66);
            edgeCost.Add(e_f, 76);
            edgeCost.Add(e_h, 33);
            edgeCost.Add(f_i, 11);
            edgeCost.Add(f_j, 21);
            edgeCost.Add(g_d, 12);
            edgeCost.Add(g_h, 10);
            edgeCost.Add(h_g, 2);
            edgeCost.Add(h_i, 72);
            edgeCost.Add(i_f, 31);
            edgeCost.Add(i_h, 18);
            edgeCost.Add(i_j, 7);
            edgeCost.Add(j_f, 8);

            #endregion


            Func<Edge<string>, double> funcEdgeCost = AlgorithmExtensions.GetIndexer(edgeCost);

            // We want to use Dijkstra on this graph
            DijkstraShortestPathAlgorithm<string, Edge<string>> dijkstra = new DijkstraShortestPathAlgorithm<string, Edge<string>>(graph, funcEdgeCost);

            // attach a distance observer to give us the shortest path distances
            VertexDistanceRecorderObserver<string, Edge<string>> vertexDistRecObserver = new VertexDistanceRecorderObserver<string, Edge<string>>(funcEdgeCost);
            vertexDistRecObserver.Attach(dijkstra);

            // Attach a Vertex Predecessor Recorder Observer to give us the paths
            VertexPredecessorRecorderObserver<string, Edge<string>> vertexPredeRecObserver = new VertexPredecessorRecorderObserver<string, Edge<string>>();
            vertexPredeRecObserver.Attach(dijkstra);

            // Run the algorithm with A set to be the source
            dijkstra.Compute("A");


            foreach (KeyValuePair<string, double> kvp in vertexDistRecObserver.Distances)
            {
                Console.WriteLine("Distance from root to node {0} is {1}", kvp.Key, kvp.Value);
            }

            foreach (KeyValuePair<string, Edge<string>> kvp in vertexPredeRecObserver.VertexPredecessors)
            {
                Console.WriteLine("If you want to get to {0} you have to enter through the in edge {1}", kvp.Key, kvp.Value);
            }


            Console.WriteLine("\n\nShortest paths");

            foreach (string source in strVertexes)
            {
                foreach (string target in strVertexes)
                {
                    //string source  "A",
                    //string target  "F",

                    Console.Write("\nShortest path from " + source + " to " + target + ": ");


                    // vis can create all the shortest path in the graph
                    // and returns a delegate that can be used to retreive the graphs
                    TryFunc<string, IEnumerable<Edge<string>>> tryGetPath = graph.ShortestPathsDijkstra(funcEdgeCost, source);

                    // enumerating path to targetCity, if any
                    IEnumerable<Edge<string>> path;
                    if (tryGetPath(target, out path))
                    {
                        foreach (var e in path)
                        {
                            Console.Write(e + ", ");
                        }
                    }
                }
            }



            Console.WriteLine("\n\n\nPress ENTER to exit...");
            Console.ReadLine();

        }





    }

    public class EFAEdge<T> : Edge<string>
    {

        public double Cost { get; }

        public EFAEdge(string src, string dest) : this(src, dest, 0) { }

        public EFAEdge(string src, string dest, double cost) : base(src, dest)
        {
            this.Cost = cost;
        }
    }
}