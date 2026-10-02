// Inline external JavaScript files into script tags to create a single‑file HTML page.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample JavaScript file
            string scriptPath = Path.Combine(Path.GetTempPath(), "sample.js");
            File.WriteAllText(scriptPath, "console.log('Hello from external script');");

            // Prepare sample HTML file referencing the external script
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = $"<html><head><script src=\"{Path.GetFileName(scriptPath)}\"></script></head><body><h1>Test</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure save options to embed JavaScript
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Save the single‑file HTML
            string outputPath = Path.Combine(Path.GetTempPath(), "output.html");
            document.Save(outputPath, options);

            Console.WriteLine("Single‑file HTML saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}