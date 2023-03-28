using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GeneralClasses.DateTimeTests
{
    class DateTimeTests
    {
        string[] strFormats =
         {
                //"M/d/yyyy h:mm:ss tt",
                //"M/d/yyyy h:mm tt",
                //"MM/dd/yyyy hh:mm:ss",
                //"M/d/yyyy h:mm:ss",
                //"M/d/yyyy hh:mm tt",
                //"M/d/yyyy hh tt",
                //"M/d/yyyy h:mm",
                //"M/d/yyyy h:mm",
                //"MM/dd/yyyy hh:mm",
                //"M/dd/yyyy hh:mm",

                "dd-MM-yyyy HH:mm:ss",
                "dd-MM-yyyy HH:mm:ss,fff",
                "dd-MM-yyyy HH:mm:ss,ffffff",

                "dd/MM/yyyy HH:mm:ss",
                "dd/MM/yyyy HH:mm:ss,fff",
                "dd/MM/yyyy HH:mm:ss,ffffff",

                "dd.MM.yyyy HH:mm:ss",
                "dd.MM.yyyy HH:mm:ss,fff",
                "dd.MM.yyyy HH:mm:ss,ffffff",
                "dd.MM.yyyy HH:mm:ss.fff",
                "dd.MM.yyyy HH:mm:ss.ffffff",
            };

        string[] strValues =
        {
             "5-815",
             "14-03-2018 22:23:34",
             "14-03-2018 22:23:34,999",
             "09-03-2018 00.00.00,000000",
             "09/03/2018 00.00.00,000000",
             "09.03.2018 00.00.00",
             "09.03.2018 00.00.00,000000",
        };

        DateTime dateValue;


        DateTimeTests()
        {
            try
            {

                foreach (string dateString in strValues)
                {
                    foreach (string format in strFormats)
                    {
                        if (DateTime.TryParseExact(dateString,
                                               format,
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None,
                                               out dateValue))
                        {
                            System.Console.WriteLine("Converted '{0}' to {1} using {2}.", dateString, dateValue, format);
                        }
                        else
                        {
                            //System.Console.WriteLine("Unable to convert '{0}' to a date.", dateString);
                        }
                    }
                }















                //String strDT = "5-815";
                //DateTime d;

                //DateTime.TryParse(strDT, out d);
                //Console.WriteLine("SIMPLE " + strDT + " becomes " + d);

                //DateTime.TryParse(strDT, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
                //Console.WriteLine("COMSIM " + strDT + " becomes " + d);

                //strDT = "04-03-2018 22:23:34";
                //DateTime.TryParse(strDT, out d);
                //Console.WriteLine("SIMPLE " + strDT + " becomes " + d);

                //DateTime.TryParse(strDT, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
                //Console.WriteLine("COMSIM " + strDT + " becomes " + d);


               // strDT = "5-815";
               //// String[] strFormats = { "dd-MM-yyyy HH:mm:ss.fff"/*, "dd.MM.yyyy hh:mm:ss", "dd-MM-yyyy hh:mm:ss", "MM/dd/yyyy hh:mm:ss" */};

               // DateTime.TryParseExact(strDT, strFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
               // Console.WriteLine("EXACT " + strDT + " becomes " + d);

               // strDT = "14-03-2018 22:23:34.999";
               // DateTime.TryParseExact(strDT, strFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
               // Console.WriteLine("EXACT " + strDT + " becomes " + d);

               // strDT = "09.03.2018 00.00.00";
               // DateTime.TryParseExact(strDT, strFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
               // Console.WriteLine("EXACT " + strDT + " becomes " + d);

               // strDT = "09.03.2018 00.00.00,000000";
               // DateTime.TryParseExact(strDT, strFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
               // Console.WriteLine("EXACT " + strDT + " becomes " + d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void __Main(String[] argv)
        {
            string[] formats = 
            {
                "M/d/yyyy h:mm:ss tt",
                "M/d/yyyy h:mm tt",
                "MM/dd/yyyy hh:mm:ss",
                "M/d/yyyy h:mm:ss",
                "M/d/yyyy hh:mm tt",
                "M/d/yyyy hh tt",
                "M/d/yyyy h:mm",
                "M/d/yyyy h:mm",
                "MM/dd/yyyy hh:mm",
                "M/dd/yyyy hh:mm",

                "dd-MM-yyyy hh:mm:ss",
                "dd-MM-yyyy HH:mm:ss",
                "DD-MM-YYYY HH24:MI:SS",
                "DD/MM/YYYY HH24:MI:SS",
            };
            string[] dateStrings = 
            {
                "04-03-2018 10:23:34",
                "04/03/2018 10:23:34",
                "04-03-2018 22:23:34",
                "04/03/2018 22:23:34",
                "16-03-2018 10:23:34",
                "16/03/2018 10:23:34",
                "16-03-2018 22:23:34",
                "16/03/2018 22:23:34",
                "5-815",
                "",
                "5/1/2014 6:32 PM",
                "05/01/2014 6:32:05 PM",
                "5/1/2014 6:32:00",
                "05/01/2014 06:32",
                "05/01/2014 06:32:00 PM",
                "05/01/2014 06:32:00",
            };
            DateTime dateValue;

            foreach (string dateString in dateStrings)
            {
                foreach (string format in formats)
                {
                    if (DateTime.TryParseExact(dateString,
                                           format,
                                           CultureInfo.InvariantCulture, //new CultureInfo("en-US"),
                                           DateTimeStyles.None,
                                           out dateValue))
                    {
                        System.Console.WriteLine("Converted '{0}' to {1} using {2}.", dateString, dateValue, format);
                    }
                    else
                    {
                        //System.Console.WriteLine("Unable to convert '{0}' to a date.", dateString);
                    }
                }
            }

            Console.WriteLine("\n\nPress ENTER 2 exit...");
            Console.ReadLine();
        }

        public static void _Main(string[] args)
        {
            Console.WriteLine("\n");

            new DateTimeTests();

            Console.WriteLine("\n\nPress ENTER 2 exit...");
            Console.ReadLine();
        }
    }
}
