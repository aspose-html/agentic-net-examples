// Set custom fonts folder, load HTML using local font files, and verify text renders with those fonts.

using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare a simple HTML file
                string htmlPath = "sample.html";
                if (!File.Exists(htmlPath))
                {
                    File.WriteAllText(htmlPath,
                        "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose.HTML</h1></body></html>");
                }

                // Create Aspose.Html configuration
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                // Obtain the user agent service and set fonts lookup folder
                Aspose.Html.Services.IUserAgentService service =
                    (Aspose.Html.Services.IUserAgentService)configuration.GetService(
                        typeof(Aspose.Html.Services.IUserAgentService));
                service.FontsSettings.SetFontsLookupFolder(Directory.GetCurrentDirectory());

                // Load the HTML document with the configuration
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

                // Define output PDF path
                string pdfPath = "output.pdf";

                // Convert HTML to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                Console.WriteLine($"PDF successfully saved to: {Path.GetFullPath(pdfPath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}