using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralClasses.Strings
{
    /// <summary>
    /// 
    /// https://www.c-sharpcorner.com/article/understanding-string-interpolation-in-c-sharp/
    /// 
    /// Syntax of string interpolation starts with a ‘$’ symbol and expressions are defined within a bracket {} using the following syntax. 
    /// {<interpolatedExpression>[,<alignment>] [:<formatString>]}
    /// Where: 
    /// interpolatedExpression - The expression that produces a result to be formatted
    /// alignment - The constant expression whose value defines the minimum number of characters 
    ///             in the string representation of the result of the interpolated expression. If positive, 
    ///             the string representation is right-aligned; if negative, it's left-aligned.
    /// formatString - A format string that is supported by the type of the expression result.
    ///
    /// </summary>
class StringInterpolaX
    {


        public static void _Main(string[] args)
        {
            Console.WriteLine("\nConcatenates a string where an object, author as a part of the string interpolation:");

            {
                string author = "Mahesh Chand";
                string hello = $"Hello {author} !";
                Console.WriteLine(hello);
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Creates a string by concatenating values of four different types of variables:");
            {
                // Simple String Interpolation  
                string author = "Mahesh Chand";
                string book = "Programming C#";
                int year = 2018;
                decimal price = 45.95m;
                string hello = $"{author} is an author of {book} . \n" + $"The book price is ${price} and was published in year {year}. ";
                Console.WriteLine(hello);

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Creates a string with spacing and adds 20 characters after the first object:");
                // Use spacing - add 20 chars  
                Console.WriteLine($"{author}{book,20}");
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Uses an expression in a string interpolation operation:");
                // Use an expression  
                Console.WriteLine($"Book {book} price is {(price < 50 ? "50" : "45")} .");

            }

            Console.WriteLine("\n\nPress ENTER 2 exit...");
            Console.ReadLine();
        }
    }
}
