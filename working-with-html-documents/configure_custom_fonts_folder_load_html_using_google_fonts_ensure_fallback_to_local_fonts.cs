// Configure custom fonts folder, load HTML using Google Fonts, and ensure fallback to local fonts.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare working directory
            string workingDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(workingDir);

            // Paths for input HTML, output PDF and fonts folder
            string htmlFilePath = Path.Combine(workingDir, "sample.html");
            string outputPdfPath = Path.Combine(workingDir, "output.pdf");
            string fontsFolder = Path.Combine(workingDir, "fonts");
            Directory.CreateDirectory(fontsFolder);

            // Create a simple HTML file if it does not exist
            if (!File.Exists(htmlFilePath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Test</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
                File.WriteAllText(htmlFilePath, htmlContent);
            }

            // Configure Aspose.HTML and set custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
            {
                // Convert HTML to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);
            }

            Console.WriteLine("PDF conversion completed successfully.");
            Console.WriteLine("Output file: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}