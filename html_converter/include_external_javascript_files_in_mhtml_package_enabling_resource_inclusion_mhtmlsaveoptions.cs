// Include external JavaScript files in MHTML package by enabling resource inclusion in MHTMLSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string sourcePath = "input.html";
            // Desired output MHTML file path
            string outputPath = "output.mht";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Create MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Include external JavaScript files in the MHTML package
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Convert the HTML document to MHTML using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}