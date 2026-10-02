// Load an HTML file with external JavaScript and ensure scripts execute during PDF rendering using default options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML and external JavaScript files
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "AsposeHtmlExample");
            Directory.CreateDirectory(baseDir);

            string jsPath = Path.Combine(baseDir, "script.js");
            File.WriteAllText(jsPath,
                "function showMessage(){ document.body.innerHTML += '<p>JS Executed</p>'; }" +
                "window.onload = showMessage;");

            string htmlPath = Path.Combine(baseDir, "sample.html");
            File.WriteAllText(htmlPath,
                "<!DOCTYPE html>" +
                "<html><head><title>Test</title>" +
                "<script src=\"script.js\"></script>" +
                "</head><body><h1>Hello World</h1></body></html>");

            // Configure to allow script execution
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document with the configuration
            var document = new Aspose.Html.HTMLDocument(htmlPath, config);

            // Set default PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output PDF path
            string outputPath = Path.Combine(baseDir, "output.pdf");

            // Convert HTML to PDF, scripts will be executed
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}