// Create a Uri object for the target URL.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a Uri object for the target URL
            Uri targetUrl = new Uri("https://www.example.com");

            // Output the Uri to verify creation
            Console.WriteLine($"Created Uri: {targetUrl}");
        }
        catch (Exception ex)
        {
            // Handle any errors that may occur during Uri creation
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}