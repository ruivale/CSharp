using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    class IEnumerableTests
    {
        private static int N_ITEMS = 25;
        private static List<Location> lLocations = new List<Location>(N_ITEMS);

        static IEnumerableTests()
        {
            for (int i=0; i<N_ITEMS; i++)
            {
                lLocations.Add(new Location(i, "Item nbr " + i));
            }
        }
            

        static void Main(string[] args)
        {
            Console.WriteLine("Executing... \n");

            var locations = getLocationsById(15);

            foreach(var l in locations)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine("\n\nPress ENTER to exit...");
            Console.ReadLine();

        }

        static IEnumerable<Location> getLocationsById(int id)
        {
            return lLocations.Where(l => l.getId() == id);
        }
    }

    class Location
    {
        private int id;
        private string desc;

        public Location(int id, string desc)
        {
            this.id = id;
            this.desc = desc;
        }

        public int getId()
        {
            return this.id;
        }

        public string getDesc()
        {
            return this.desc;
        }

        public override string ToString()
        {
            return "Location id:" + this.id + " desc:" + this.desc+".";
        }
    }
}
