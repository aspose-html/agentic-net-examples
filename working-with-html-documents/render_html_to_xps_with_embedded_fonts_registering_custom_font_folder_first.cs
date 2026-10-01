// Render HTML to XPS format with embedded fonts by registering custom font folder first.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string currentDir = Directory.GetCurrentDirectory();
            string htmlPath = Path.Combine(currentDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Output PDF path
            string outputPdfPath = Path.Combine(currentDir, "output.pdf");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Set fonts lookup folder (using system fonts folder)
            string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Convert to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"HTML file: {htmlPath}");
            Console.WriteLine($"PDF file: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
        }
    }
}