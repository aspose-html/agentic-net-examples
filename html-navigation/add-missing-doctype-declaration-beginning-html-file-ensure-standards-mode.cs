// Add a missing DOCTYPE declaration at the beginning of the HTML file to ensure standards mode.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the original document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the original HTML content (without DOCTYPE)
            string htmlContent = document.DocumentElement.OuterHTML;

            // Read the raw file content to check for existing DOCTYPE
            string rawContent = File.ReadAllText(inputPath);
            string modifiedHtml;

            if (rawContent.TrimStart().StartsWith("<!DOCTYPE", StringComparison.OrdinalIgnoreCase))
            {
                // DOCTYPE already present, keep original content
                modifiedHtml = rawContent;
            }
            else
            {
                // Prepend standard HTML5 DOCTYPE
                modifiedHtml = "<!DOCTYPE html>\n" + htmlContent;
            }

            // Create a new document from the modified HTML string
            Aspose.Html.HTMLDocument updatedDocument = new Aspose.Html.HTMLDocument(modifiedHtml, "about:blank");

            // Save the updated document
            updatedDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}