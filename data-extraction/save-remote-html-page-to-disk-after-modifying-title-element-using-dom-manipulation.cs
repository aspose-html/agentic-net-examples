// Save a remote HTML page to disk after modifying its title element using DOM manipulation.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            document.Title = "Modified Title";
            document.Save(outputPath);

            Console.WriteLine($"HTML page saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}