// Set custom user style sheet, load a page with default styles, and compare rendered appearance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.html";
            string defaultPdfPath = "default.pdf";
            string customPdfPath = "custom.pdf";

            // Create a simple HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1><p>This is a paragraph.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // ---------- Render with default styles ----------
            // Load the HTML document using default configuration
            Aspose.Html.HTMLDocument defaultDocument = new Aspose.Html.HTMLDocument(inputPath);
            // Prepare PDF save options
            Aspose.Html.Saving.PdfSaveOptions defaultOptions = new Aspose.Html.Saving.PdfSaveOptions();
            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(defaultDocument, defaultOptions, defaultPdfPath);

            // ---------- Render with custom user stylesheet ----------
            // Create a configuration and set a custom stylesheet via UserAgentService
            using (Aspose.Html.Configuration config = new Aspose.Html.Configuration())
            {
                // Retrieve the user agent service
                Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)config.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                // Define custom CSS
                string customCss = "h1 { color: red; } p { font-weight: bold; }";
                // Apply the custom stylesheet
                userAgentService.UserStyleSheet = customCss;

                // Load the same HTML document with the custom configuration
                Aspose.Html.HTMLDocument customDocument = new Aspose.Html.HTMLDocument(inputPath, config);
                // Prepare PDF save options
                Aspose.Html.Saving.PdfSaveOptions customOptions = new Aspose.Html.Saving.PdfSaveOptions();
                // Convert HTML to PDF with custom styles
                Aspose.Html.Converters.Converter.ConvertHTML(customDocument, customOptions, customPdfPath);
            }

            // ---------- Simple comparison ----------
            // Compare file sizes as a basic indication of visual differences
            long defaultSize = new FileInfo(defaultPdfPath).Length;
            long customSize = new FileInfo(customPdfPath).Length;
            Console.WriteLine($"Default PDF size: {defaultSize} bytes");
            Console.WriteLine($"Custom PDF size: {customSize} bytes");
            if (defaultSize != customSize)
            {
                Console.WriteLine("The PDFs differ, indicating that the custom stylesheet affected rendering.");
            }
            else
            {
                Console.WriteLine("The PDFs have the same size; visual differences may be subtle.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}