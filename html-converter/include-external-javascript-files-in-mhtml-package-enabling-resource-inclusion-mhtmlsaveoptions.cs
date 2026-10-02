// Include external JavaScript files in MHTML package by enabling resource inclusion in MHTMLSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string scriptPath = "script.js";
            string outputPath = "output.mhtml";

            // Create external JavaScript file
            File.WriteAllText(scriptPath, "function greet(){ console.log('Hello from external JS'); } greet();");

            // Create HTML file that references the external JavaScript
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title><script src=\"script.js\"></script></head><body><h1>Test</h1></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            // Configure MHTML save options to embed JavaScript resources
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Convert HTML to MHTML
            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, options, outputPath);

            Console.WriteLine("MHTML file created at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}