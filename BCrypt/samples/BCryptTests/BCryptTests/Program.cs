using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCryptTests
{
    class Program
    {
        private static string strPlainPassword = "hoje";
        private static string strStoredHash = 
            //"$2a$05$3tXbQLPGCKkZaMwrcvUpEOrlPNkvlAK7H2UseGBl2QmPmfXfHugju"; // hoje (salt = 5)
            "$2a$10$xoyqfEnuznFsJf/cXDg5EeSPSc4zRvMHQypa6erDRBJJZVItG15Zi"; // hoje (salt = 10)
            //"$2a$10$EctRUDQl8.kMvpzzknVFjOmYSQENjYkXbq2QeLeUakfOjfKeOVH0i"; // password
        private static string strCandidatePassword = strPlainPassword;

        static void Main(string[] args)
        {
            string hashed = BCrypt.HashPassword(strPlainPassword, BCrypt.GenerateSalt(10));

            Console.WriteLine("\"" + strPlainPassword + "\" hashed: " + hashed);

            Console.Write("Write the candidate password: ");
            strCandidatePassword = Console.ReadLine();

            if (BCrypt.CheckPassword(
                    strCandidatePassword, 
                    //hashed)) {
                    strStoredHash)) {
                Console.WriteLine("It matches");
            }
            else
            {
                Console.WriteLine("It does not match");
            }

            Console.WriteLine("Press ENTER 2 exit ...");
            Console.ReadLine();
        }
    }
}
