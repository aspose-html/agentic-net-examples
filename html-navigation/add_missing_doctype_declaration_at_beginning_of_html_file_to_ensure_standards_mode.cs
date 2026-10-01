// Add a missing DOCTYPE declaration at the beginning of the HTML file to ensure standards mode.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file without DOCTYPE if it doesn't exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document using Aspose.Html
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the outer HTML of the document
            string html = document.DocumentElement.OuterHTML;

            // Add DOCTYPE if missing
            if (!html.TrimStart().StartsWith("<!DOCTYPE", StringComparison.OrdinalIgnoreCase))
            {
                html = "<!DOCTYPE html>\n" + html;
            }

            // Save the modified HTML to the output file
            File.WriteAllText(outputPath, html);

            Console.WriteLine("HTML file processed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}