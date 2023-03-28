using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsoleAppsTests
{
    class TestingDateTime
    {
        /// <summary>
        /// 
        /// Results:
        /// DateTime display listing specifier and result:
        /// 
        /// d = 23-04-2008
        /// D = quarta-feira, 23 de Abril de 2008
        /// f = quarta-feira, 23 de Abril de 2008 16:42
        /// F = quarta-feira, 23 de Abril de 2008 16:42:59
        /// g = 23-04-2008 16:42
        // /G = 23-04-2008 16:42:59
        /// M = 23-4
        /// R = Wed, 23 Apr 2008 16:42:59 GMT
        /// s = 2008-04-23T16:42:59
        /// t = 16:42
        /// T = 16:42:59
        /// u = 2008-04-23 16:42:59Z
        /// U = quarta-feira, 23 de Abril de 2008 15:42:59
        /// Y = Abril de 2008
        /// 
        /// DateTime.Month = 4
        /// DateTime.DayOfWeek = Wednesday
        /// DateTime.TimeOfDay = 16:42:59.4501778
        /// DateTime.Ticks = 633445657794501778
        ///
        /// </summary>
        public static void Main_()
        {

            DateTime CurrTime = DateTime.Now;

            Console.WriteLine("DateTime display listing specifier and result:\n");

            Console.WriteLine("d = {0:d}", CurrTime); // Short date mm/dd/yyyy

            Console.WriteLine("D = {0:D}", CurrTime); // Long date day, month dd, yyyy

            Console.WriteLine("f = {0:f}", CurrTime); // Full date/short time day, month dd, yyyy hh:mm

            Console.WriteLine("F = {0:F}", CurrTime); // Full date/full time day, month dd, yyyy HH:mm:ss AM/PM

            Console.WriteLine("g = {0:g}", CurrTime); // Short date/short time mm/dd/yyyy HH:mm

            Console.WriteLine("G = {0:G}", CurrTime); // Short date/long time mm/dd/yyyy hh:mm:ss

            Console.WriteLine("M = {0:M}", CurrTime); // Month dd

            Console.WriteLine("R = {0:R}", CurrTime); // ddd Month yyyy hh:mm:ss GMT

            Console.WriteLine("s = {0:s}", CurrTime); // yyyy-mm-dd hh:mm:ss can be sorted!

            Console.WriteLine("t = {0:t}", CurrTime); // Short time hh:mm AM/PM

            Console.WriteLine("T = {0:T}", CurrTime); // Long time hh:mm:ss AM/PM

            Console.WriteLine("u = {0:u}", CurrTime); // yyyy-mm-dd hh:mm:ss universal/sortable

            Console.WriteLine("U = {0:U}", CurrTime); // day, month dd, yyyy hh:mm:ss AM/PM

            Console.WriteLine("Y = {0:Y}", CurrTime); // Month, yyyy

            Console.WriteLine();

            Console.WriteLine("DateTime.Month = " + CurrTime.Month); // number of month

            Console.WriteLine("DateTime.DayOfWeek = " + CurrTime.DayOfWeek); // full name of day

            Console.WriteLine("DateTime.TimeOfDay = " + CurrTime.TimeOfDay); // 24 hour time



            // number of 100-nanosecond intervals that have elapsed since 1/1/0001, 12:00am

            // useful for time-elapsed measurements

            Console.WriteLine("DateTime.Ticks = " + CurrTime.Ticks);

            Console.WriteLine("------------------------------------------------------------------");

            Console.Read(); // wait

        }
    }
}
