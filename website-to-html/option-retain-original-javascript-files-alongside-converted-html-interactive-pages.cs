// Provide an option to retain original JavaScript files alongside converted HTML for interactive pages.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string jsPath = "script.js";

            // Create a sample JavaScript file
            System.IO.File.WriteAllText(jsPath, "function greet(){ alert('Hello'); }");

            // Create a sample HTML file that references the JavaScript file
            string htmlContent = "<!DOCTYPE html><html><head><script src=\"script.js\"></script></head><body><button onclick=\"greet()\">Click</button></body></html>";
            System.IO.File.WriteAllText(inputHtmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Configure save options to retain original JavaScript files (link them)
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            string outputHtmlPath = "output.html";

            // Save the document with the configured options
            document.Save(outputHtmlPath, options);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}