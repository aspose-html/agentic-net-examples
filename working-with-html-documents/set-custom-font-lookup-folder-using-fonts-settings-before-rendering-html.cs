// Set a custom font lookup folder using FontsSettings.SetFontsLookupFolder before rendering HTML.

using System;
using System.IO;

namespace AsposeHtmlFontLookupExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define custom fonts folder (ensure it exists)
                string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
                Directory.CreateDirectory(fontsFolder);

                // Create configuration and set the custom fonts lookup folder
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

                // Sample HTML content that references a custom font (font file should be placed in the fonts folder)
                string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        @font-face {
            font-family: 'MyFont';
            src: url('myfont.ttf');
        }
        body { font-family: 'MyFont'; }
    </style>
</head>
<body>
    <p>Hello, world with a custom font!</p>
</body>
</html>";

                // Load HTML document with the custom configuration
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

                // Convert HTML to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}