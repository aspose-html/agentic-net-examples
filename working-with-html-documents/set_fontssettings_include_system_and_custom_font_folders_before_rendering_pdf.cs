// Set FontsSettings to include both system and custom font folders before rendering to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string outputPdfPath = Path.Combine(baseDir, "output.pdf");
            string customFontsFolder = Path.Combine(baseDir, "CustomFonts");
            string systemFontsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));

            // Ensure custom fonts folder exists (can be empty for this example)
            if (!Directory.Exists(customFontsFolder))
                Directory.CreateDirectory(customFontsFolder);

            // Create a minimal HTML file
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Test</title></head><body><p style='font-family:Arial;'>Hello, Aspose.HTML!</p></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Initialize Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve the user agent service
            Aspose.Html.Services.IUserAgentService service = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            // Set fonts lookup folders (system and custom)
            service.FontsSettings.SetFontsLookupFolder(systemFontsFolder);
            service.FontsSettings.SetFontsLookupFolder(customFontsFolder);

            // Load the HTML document with the configured settings
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Prepare PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}