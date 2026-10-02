// Create a Uri object for the target URL.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var targetUri = new Uri("https://www.example.com");
            Console.WriteLine("Created Uri: " + targetUri);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}