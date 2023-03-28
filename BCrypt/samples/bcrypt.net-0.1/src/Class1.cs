using System;
using System.Collections.Generic;
using System.Text;

namespace BCryptTests
{
    class Class1
    {
        private static string strPlainPassword = "pasword";


        static void Main()
        {
            string hashed = BCrypt.HashPassword(strPlainPassword, BCrypt.GenerateSalt());

            Console.WriteLine("\"password\" hashed: "+hashed);
        }
    }
}
