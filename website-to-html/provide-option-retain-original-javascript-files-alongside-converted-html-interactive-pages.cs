// Provide an option to retain original JavaScript files alongside converted HTML for interactive pages.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML and JavaScript files
            string inputPath = "sample.html";
            string jsPath = "script.js";
            string outputPath = "output.html";

            string htmlContent = "<!DOCTYPE html><html><head><script src=\"script.js\"></script></head><body><h1>Hello</h1></body></html>";
            string jsContent = "console.log('Hello from script');";

            File.WriteAllText(inputPath, htmlContent);
            File.WriteAllText(jsPath, jsContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure save options to retain original JavaScript files
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Save the document with the configured options
            document.Save(outputPath, options);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}