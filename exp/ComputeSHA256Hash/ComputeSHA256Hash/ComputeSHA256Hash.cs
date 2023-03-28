using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Security.Cryptography;

namespace ComputeSHA256Hash
{
    /// <summary>
    /// Hashing (also known as hash functions) in cryptography is a process of mapping a binary
    /// string of an arbitrary length to a small binary string of a fixed length, known as a
    /// hash value, a hash code, or a hash. Hash functions are a common way to protect secure 
    /// sensitive data such as passwords and digital signatures. Some of the modern commonly-used 
    /// hash functions are MD5, RIPEMD160, SHA1, SHA256, SHA384, and SHA512.
    /// Hashing is a one-way conversion.You cannot un-hash hashed data.
    /// The NET framework provides cryptography-related functionality encapsulated in 
    /// System.Security.Cryptography namespace and its classes.The HashAlgorithm class is the 
    /// base class for hash algorithms including MD5, RIPEMD160, SHA1, SHA256, SHA384, and SHA512.
    /// The ComputeHash method of HashAlgorithm computes a hash.It takes a byte array or stream 
    /// as an input and returns a hash in the form of a byte array of 256 chars.
    /// </summary>
    class ComputeSHA256Hash
    {
        static void Main(string[] args)
        {
            string plainData = "Mahesh";
            Console.WriteLine("Raw data: {0}", plainData);
            string hashedData = ComputeSha256Hash(plainData);
            Console.WriteLine("Hash {0}", hashedData);
            Console.WriteLine(ComputeSha256Hash("Mahesh"));
            Console.ReadLine();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
