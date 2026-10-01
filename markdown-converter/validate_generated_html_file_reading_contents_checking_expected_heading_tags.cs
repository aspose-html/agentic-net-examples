// Validate the generated HTML file by reading its contents and checking for expected heading tags.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlFilePath = "sample.html";

            // Create sample HTML content with heading tags
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Main Heading</h1><h2>Sub Heading</h2><p>Sample paragraph.</p></body></html>";

            // Write the sample HTML to a file
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document using Aspose.Html
            HTMLDocument document = new HTMLDocument(htmlFilePath);

            // Access the body element and its text content (optional)
            HTMLElement body = document.Body;
            string bodyText = body.TextContent;

            // Read raw HTML file content for validation
            string rawHtml = File.ReadAllText(htmlFilePath);

            // Validate presence of heading tags
            bool hasH1 = rawHtml.Contains("<h1>");
            bool hasH2 = rawHtml.Contains("<h2>");

            // Output validation results
            Console.WriteLine("Validation Results:");
            Console.WriteLine("Contains <h1>: " + (hasH1 ? "Yes" : "No"));
            Console.WriteLine("Contains <h2>: " + (hasH2 ? "Yes" : "No"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}