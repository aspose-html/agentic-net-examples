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
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Ensure a sample input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><a href=\"https://example.com\" title=\"Sample \"double\" quotes\">Link</a></body></html>");
            }

            // Load HTML content from file
            string htmlContent = File.ReadAllText(inputPath);

            // Replace double quotes with single quotes
            string modifiedHtml = htmlContent.Replace("\"", "'");

            // Create HTMLDocument from modified content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(modifiedHtml, "");

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}