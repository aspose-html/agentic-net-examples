// Configure custom fonts folder, load HTML using web fonts, and ensure fallback fonts are applied.

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
            // Prepare custom fonts folder
            string fontsFolder = "CustomFonts";
            Directory.CreateDirectory(fontsFolder);

            // Prepare sample HTML file that uses a web font with fallback
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'CustomFont';
    src: url('https://example.com/nonexistent.woff2');
}
body {
    font-family: 'CustomFont', Arial, sans-serif;
}
</style>
</head>
<body>
<p>This text should use CustomFont if available, otherwise fallback to Arial.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.HTML with custom fonts lookup folder
            Configuration configuration = new Configuration();
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load HTML document with the configuration
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Convert HTML to PDF
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPdf = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);
                Console.WriteLine("Conversion succeeded. PDF saved to: " + Path.GetFullPath(outputPdf));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}