using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;



namespace GeneralClasses.Dynamic
{
    class DynamicReturnType
    {
        static void Main_(string[] args)
        {
            bool app = true;
            while (app)
            {
                Console.WriteLine("\n\nenter the data profile you want to see : High or Low. to close application hit close");
                string profile = Console.ReadLine();
                if (profile.ToLower().Equals("close"))
                {
                    app = false;
                }
                else
                {
                    dynamic obj = GetObject(profile);
                    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(obj);
                        Console.WriteLine("{0}={1}", name, value);
                    }
                }


            }

        }

        private static dynamic GetObject(string profile)
        {
            if (profile.ToLower().Equals("low"))
            {
                Low low = new Low { Name = "bhavna", FatherName = "FName" };
                return low;
            }
            else if (profile.ToLower().Equals("high"))
            {
                High high = new High { Name = "Rahul", FatherName = "Rahul Father", Subject = "Maths", DOB = "30112005" };
                return high;
            }
            else
            {
                return "not a valid option";
            }
        }

        class Low
        {
            public string Name { get; set; }
            public string FatherName { get; set; }
        }
        class High : Low
        {
            public string Subject { get; set; }
            public string DOB { get; set; }
        }

    }
}
