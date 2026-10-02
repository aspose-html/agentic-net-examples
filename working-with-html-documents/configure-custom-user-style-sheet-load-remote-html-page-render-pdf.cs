// Configure a custom user style sheet, load a remote HTML page, and render it to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();

            // Get user agent service and set custom stylesheet
            Aspose.Html.Services.IUserAgentService userAgentService = config.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgentService.UserStyleSheet = "body { background-color: #f0f0f0; font-family: Arial, sans-serif; }";

            // Load remote HTML page
            string url = "https://www.example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, config);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}