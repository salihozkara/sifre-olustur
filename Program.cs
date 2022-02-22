using System;
using System.IO;
using System.Linq;
using System.Net.Mime;


namespace GeneratePassword
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Input(out var length, out var siteName);
            WriteFile(generatePassword(length), "", siteName);
        }

        // Generate a random password
        private static string generatePassword(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            Console.WriteLine(password);
            return password;
        }

        // i need input from user
        private static void Input(out int length, out string siteName)
        {
            Console.WriteLine("Enter length of password");
            length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter site name");
            siteName = Console.ReadLine();
        }

        // password , username and site name to write in file 
        private static void WriteFile(string password, string username, string siteName)
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/passwords.txt";
            File.AppendAllText(filePath, siteName + ":\t" + username + ":\t" + password + Environment.NewLine);
        }
    }
}