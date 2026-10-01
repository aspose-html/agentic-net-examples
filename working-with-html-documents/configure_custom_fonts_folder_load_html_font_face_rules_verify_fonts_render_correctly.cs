// Configure custom fonts folder, load HTML using @font-face rules, and verify fonts render correctly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Ensure a fonts folder exists (can be empty)
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            Directory.CreateDirectory(fontsFolder);

            // Configure Aspose.HTML
            var configuration = new Aspose.Html.Configuration();
            var userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Load HTML document with configuration
            var document = new Aspose.Html.HTMLDocument(inputPath, configuration);

            // Convert to image (PNG)
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions();
            string imageOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
            Aspose.Html.Converters.Converter.ConvertHTML(document, imageOptions, imageOutputPath);

            // Convert to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            string pdfOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfOutputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Image saved to: {imageOutputPath}");
            Console.WriteLine($"PDF saved to: {pdfOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}