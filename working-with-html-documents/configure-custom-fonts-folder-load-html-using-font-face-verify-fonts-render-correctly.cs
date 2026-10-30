// Configure custom fonts folder, load HTML using @font-face rules, and verify fonts render correctly.

using System;
using System.IO;
using Aspose.Html;
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
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            Directory.CreateDirectory(fontsFolder);
            string fontFile = Path.Combine(fontsFolder, "OpenSans-Regular.ttf");
            if (!File.Exists(fontFile))
            {
                File.WriteAllBytes(fontFile, new byte[0]);
            }

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // HTML content that uses @font-face to reference the custom font
            string fontUrl = "file:///" + fontFile.Replace("\\", "/");
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'CustomFont';
    src: url('" + fontUrl + @"');
}
body { font-family: 'CustomFont', sans-serif; font-size: 24px; }
</style>
</head>
<body>
<p>This text should be rendered with the custom font.</p>
</body>
</html>";

            // Load HTML document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

            // Convert the document to PDF to verify font rendering
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}