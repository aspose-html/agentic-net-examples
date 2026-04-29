// Save the generated HTML preview to a temporary file for automated testing workflows.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be previewed
            string htmlContent = "<html><body><h1>Preview</h1></body></html>";
            // Base URI for resolving relative resources (if any)
            string baseUri = "http://example.com/";

            // Generate a temporary file path for the preview
            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "preview.html");

            // Create an HTMLDocument from the string content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the document to the temporary file
            document.Save(tempPath);

            Console.WriteLine($"HTML preview saved to: {tempPath}");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}