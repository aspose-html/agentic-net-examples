// Set a custom font lookup folder using FontsSettings.SetFontsLookupFolder before rendering HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define a custom fonts folder
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            Directory.CreateDirectory(fontsFolder);

            // Create Aspose.HTML configuration and set the fonts lookup folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Sample HTML content that could use a custom font
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        @font-face {
            font-family: 'CustomFont';
            src: url('customfont.ttf');
        }
        body { font-family: 'CustomFont'; }
    </style>
</head>
<body>
    <p>Hello, world with a custom font!</p>
</body>
</html>";

            // Load the HTML document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}