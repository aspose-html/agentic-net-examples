// Configure custom fonts folder, load HTML using Google Fonts, and ensure fallback to local fonts.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string currentDir = Directory.GetCurrentDirectory();
            string fontsFolder = Path.Combine(currentDir, "fonts");
            Directory.CreateDirectory(fontsFolder);

            // (Optional) Place a local font file in the fonts folder.
            // For demonstration, we assume a font file named "OpenSans-Regular.ttf" exists there.

            // Create sample HTML that uses Google Font and falls back to a local font
            string htmlPath = Path.Combine(currentDir, "sample.html");
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Custom Fonts Example</title>
    <link href='https://fonts.googleapis.com/css2?family=Roboto&display=swap' rel='stylesheet'>
    <style>
        @font-face {
            font-family: 'OpenSans';
            src: url('fonts/OpenSans-Regular.ttf') format('truetype');
        }
        body {
            font-family: 'OpenSans', 'Roboto', sans-serif;
            font-size: 24px;
            margin: 40px;
        }
    </style>
</head>
<body>
    <p>This text should use the local OpenSans font if available, otherwise fall back to Google Roboto.</p>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.HTML with custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Convert to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPdf = Path.Combine(currentDir, "output.pdf");
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}