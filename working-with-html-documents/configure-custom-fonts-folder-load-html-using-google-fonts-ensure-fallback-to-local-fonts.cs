// Configure custom fonts folder, load HTML using Google Fonts, and ensure fallback to local fonts.

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
            string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "fonts");
            string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Ensure fonts folder exists
            Directory.CreateDirectory(fontsFolder);

            // Create a minimal HTML file that uses a Google Font with a local fallback
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Custom Fonts Example</title>
    <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap' rel='stylesheet'>
    <style>
        body { font-family: 'Roboto', 'MyLocalFont', sans-serif; font-size: 24px; }
    </style>
</head>
<body>
    <p>This text should be rendered with Roboto from Google Fonts, or fallback to a local font.</p>
</body>
</html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Configure Aspose.HTML with custom fonts lookup folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document using the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}