// Include external JavaScript files in MHTML package by enabling resource inclusion in MHTMLSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal external JavaScript file
            string jsPath = "script.js";
            System.IO.File.WriteAllText(jsPath, "console.log('Hello from external JS');");

            // HTML content referencing the external JavaScript file
            string html = "<!DOCTYPE html><html><head><script src=\"script.js\"></script></head><body><h1>Sample</h1></body></html>";

            // Output MHTML file path
            string outputPath = "output.mhtml";

            // Configure MHTML save options to include external resources
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Convert HTML string to MHTML package
            Aspose.Html.Converters.Converter.ConvertHTML(html, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}