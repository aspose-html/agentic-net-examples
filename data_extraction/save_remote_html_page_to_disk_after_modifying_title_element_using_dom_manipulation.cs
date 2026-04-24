// Save a remote HTML page to disk after modifying its title element using DOM manipulation.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Remote HTML page URL
            string url = "https://example.com";

            // Local file path to save the modified page
            string outputPath = "modified.html";

            // Load the remote page into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Update the title element
            document.Title = "New Title";

            // Save the modified document to disk
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}