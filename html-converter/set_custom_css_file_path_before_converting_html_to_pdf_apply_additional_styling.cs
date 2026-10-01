// Set custom CSS file path before converting HTML to PDF to apply additional styling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string cssPath = "custom.css";
            string pdfPath = "output.pdf";

            // Create sample HTML file
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello, World!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create custom CSS file
            string cssContent = "h1 { color: red; font-size: 48px; }";
            File.WriteAllText(cssPath, cssContent);

            // Configure Aspose.HTML and set custom CSS
            Aspose.Html.Configuration configuration = Aspose.Html.Configuration.Create();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssPath;

            // Load HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}