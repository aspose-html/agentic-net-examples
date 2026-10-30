// Set custom CSS file path before converting HTML to PDF to apply additional styling.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string cssPath = "custom.css";
            string pdfPath = "output.pdf";

            // Create sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create sample CSS content
            string cssContent = "h1 { color: red; }";
            File.WriteAllText(cssPath, cssContent);

            // Create Aspose.HTML configuration
            Configuration configuration = Configuration.Create();

            // Get user agent service and set custom CSS file
            IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgent.UserStyleSheet = cssPath;

            // Load HTML document with the configuration
            HTMLDocument document = new HTMLDocument(htmlPath, configuration);

            // Convert HTML to PDF
            PdfSaveOptions options = new PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}