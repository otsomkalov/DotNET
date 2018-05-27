using System;
using System.Text;

namespace Lab1
{
    internal static class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Enter the text that will be encrypted:");
            var text = Console.ReadLine();

            Console.WriteLine("Enter encyption key (8 symbols length):");
            var key = Console.ReadLine();

            var encrypted = DES.DES.Encrypt(text, key);
            Console.WriteLine("Encrypted text (base64):");
            Console.WriteLine(encrypted);

            Console.WriteLine();

            Console.WriteLine("Decrypted text:");
            Console.WriteLine(DES.DES.Decrypt(encrypted, key));
        }
    }
}