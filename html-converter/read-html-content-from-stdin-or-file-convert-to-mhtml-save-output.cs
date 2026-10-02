// Read HTML content from standard input or file, convert it to MHTML using Converter.ConvertHTML, and save the output as an .mhtml file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Set MHTML save options
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

            // Convert HTML to MHTML and save the result
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. MHTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}