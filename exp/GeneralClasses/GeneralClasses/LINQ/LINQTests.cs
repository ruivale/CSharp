using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralClasses.LINQ
{
    class LINQTests
    {
        static void _Main()
        {
            int[] numbers = {};
            int first = numbers.FirstOrDefault();
            Console.WriteLine("1: "+first);
            first = numbers.FirstOrDefault();
            Console.WriteLine("2: " + first);


            Console.WriteLine("\nPress ENTER to exit...");
            Console.ReadLine();

        }
    }
}
