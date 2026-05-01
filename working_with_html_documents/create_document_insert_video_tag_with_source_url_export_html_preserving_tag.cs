// Create a document, insert a video tag with source URL, and export to HTML preserving the tag.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with a video element
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><video controls src=\"https://example.com/video.mp4\"></video></body></html>";
            // Base URI for resolving relative URLs (empty in this case)
            string baseUri = "";

            // Create an HTML document from the string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the document to an HTML file, preserving the video tag
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}