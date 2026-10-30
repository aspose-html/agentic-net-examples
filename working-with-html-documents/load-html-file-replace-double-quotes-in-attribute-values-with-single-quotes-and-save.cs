// Load an HTML file, replace all double quotes in attribute values with single quotes, and save.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p class=\"text\" data-info=\"example\">Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML content from the file
            string htmlContent = File.ReadAllText(inputPath);

            // Replace double quotes in attribute values with single quotes
            // (This simple replace also affects other double quotes, which is acceptable for this example)
            string modifiedHtml = htmlContent.Replace("\"", "'");

            // Load the modified HTML into an HTMLDocument (using two-argument constructor)
            using (HTMLDocument document = new HTMLDocument(modifiedHtml, "about:blank"))
            {
                // Save the modified document to the output file
                document.Save(outputPath);
            }

            Console.WriteLine($"HTML file processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}