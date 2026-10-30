// Set custom fonts folder, load HTML using local font files, and verify text renders with those fonts.

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
            // Prepare directories
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            Directory.CreateDirectory(baseDir);
            string fontsDir = Path.Combine(baseDir, "fonts");
            Directory.CreateDirectory(fontsDir);

            // Create a dummy font file
            string fontPath = Path.Combine(fontsDir, "CustomFont.ttf");
            if (!File.Exists(fontPath))
            {
                File.WriteAllBytes(fontPath, new byte[] { 0 });
            }

            // Create sample HTML that uses the custom font
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><style>" +
                                 "@font-face {font-family: 'CustomFont'; src: url('fonts/CustomFont.ttf');}" +
                                 "body {font-family: 'CustomFont';}" +
                                 "</style></head><body><p>Hello, custom font!</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.Html to use the custom fonts folder
            Configuration configuration = new Configuration();
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsDir);

            // Load the HTML document with the custom configuration
            HTMLDocument document = new HTMLDocument(htmlPath, configuration);

            // Convert the document to PDF
            PdfSaveOptions options = new PdfSaveOptions();
            string outputPdf = Path.Combine(baseDir, "output.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);

            Console.WriteLine("PDF generated at: " + outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}