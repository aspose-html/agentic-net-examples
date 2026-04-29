// Load HTML from a Stream object into the validator to support network or memory‑based sources.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
            {
                var document = new Aspose.Html.HTMLDocument(stream, "http://example.com/");
                Console.WriteLine("HTML loaded from stream successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}