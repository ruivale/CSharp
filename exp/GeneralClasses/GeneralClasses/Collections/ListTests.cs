using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralClasses.Collections
{
    public class ListTests
    {
        ListTests()
        {
            List<User> list = new List<User>(5);
            list.Add(new User(1, "um", 1));
            list.Add(new User(3, "três", 9));
            list.Add(new User(6, "seis", 9));
            list.Add(new User(2, "dois", 5));
            list.Add(new User(8, "dois", 5));
            list.Add(new User(7, "sete", 5));
            list.Add(new User(5, "cinco", 4));


            int id = 4;

            if (list.Find(k => k._id == id) == null)
            {
                Console.WriteLine("Is "+id+" present? IS NULL");
            }
            else
            {
                Console.WriteLine("Is " + id + " present? IS NOT NULL");
            }


            Console.WriteLine("\nOrdering by age and then by id ...");
            list.OrderBy(u => u._age).OrderBy(u => u._id).ToList().ForEach(u => Console.WriteLine("\t"+u));


            Console.WriteLine("\nGrouping by age 5 and then by id ...");
            List<User> lUserWithAge5 = list.FindAll(u => u._age == 5).ToList();
            lUserWithAge5.OrderBy(u => u._id).ToList().ForEach(u =>
            {
                Console.WriteLine("\t" + u);

                //list = lUserWithAge5.FindAll(usr => usr._id == 2).ToList();
                //list.ForEach(us => Console.WriteLine("\t\t" + us));

            });


            Console.WriteLine("\n");

            //list.Clear();

            Dictionary<int, List<User>> dicDvdItisBack =
                list.GroupBy(u => u._age).ToDictionary(grp => grp.Key, grp => grp.ToList().OrderBy(u => u._id).ToList());



            Console.WriteLine("Press ENTER 2 exit...");
            Console.ReadLine();
        }

        static void Main_()
        {
            new ListTests();
        }

    }

    class User
    {
        public int _id;
        public string _name;
        public int _age;

        public User(int id, string name, int age)
        {
            this._id = id;
            this._name = name;
            this._age = age;
        }

        
        public override string ToString()
        {
            return "User(" + this._id + "): " + this._name + " has " + this._age + " years old.";
        }
    }
}
