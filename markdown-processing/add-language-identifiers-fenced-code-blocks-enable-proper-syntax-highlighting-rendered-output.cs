// Add language identifiers to fenced code blocks to enable proper syntax highlighting in rendered output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>";

            // Load the HTML document from the content string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a new paragraph element
            var paragraph = (Aspose.Html.HTMLElement)document.CreateElement("p");
            paragraph.TextContent = "Hello, Aspose.HTML!";
            paragraph.Style.Color = "red";

            // Append the paragraph to the body
            var body = (Aspose.Html.HTMLElement)document.Body;
            body.AppendChild(paragraph);

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}