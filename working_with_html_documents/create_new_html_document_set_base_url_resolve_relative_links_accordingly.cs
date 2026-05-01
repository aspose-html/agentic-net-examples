// Create a new HTML document, set its base URL, and resolve relative links accordingly.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with a relative link
            string htmlContent = "<html><body><a href=\"page.html\">Relative Link</a></body></html>";

            // Base URI used to resolve relative URLs in the document
            string baseUri = "https://example.com/folder/";

            // Create a new HTML document with the specified base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Save the document to a file; relative links will be resolved using the base URI
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}