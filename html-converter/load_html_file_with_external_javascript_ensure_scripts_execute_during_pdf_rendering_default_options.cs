// Load an HTML file with external JavaScript and ensure scripts execute during PDF rendering using default options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string jsPath = "script.js";
            string pdfPath = "output.pdf";

            // Create external JavaScript file
            File.WriteAllText(jsPath, "document.body.innerHTML = '<h1>Hello from external script</h1>';");

            // Create HTML file referencing the external script
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Test</title></head><body><script src=\"script.js\"></script></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure to allow script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set PDF save options (default)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}