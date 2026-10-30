// Configure custom fonts folder, load HTML using web fonts, and ensure fallback fonts are applied.

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
            // Define paths
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "CustomFonts");
            string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Ensure fonts folder exists
            Directory.CreateDirectory(fontsFolder);

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Create sample HTML that uses a web font with fallback fonts
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap' rel='stylesheet'>
    <style>
        body {
            font-family: 'Roboto', Arial, sans-serif;
            font-size: 24px;
            margin: 40px;
        }
    </style>
</head>
<body>
    <p>This paragraph should be rendered with the Roboto web font. If the web font cannot be loaded, it falls back to Arial or the default sans‑serif.</p>
</body>
</html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}