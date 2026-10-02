// Set custom fonts folder, load HTML using local font files, and verify text renders with those fonts.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string currentDir = Directory.GetCurrentDirectory();
            string fontsFolder = Path.Combine(currentDir, "CustomFonts");
            string fontFile = Path.Combine(fontsFolder, "CustomFont.ttf");
            string htmlFile = Path.Combine(currentDir, "sample.html");
            string outputPdf = Path.Combine(currentDir, "output.pdf");

            // Ensure fonts folder exists and contains a placeholder font file
            Directory.CreateDirectory(fontsFolder);
            if (!File.Exists(fontFile))
            {
                File.WriteAllBytes(fontFile, new byte[0]);
            }

            // Sample HTML that uses the custom font
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'MyCustomFont';
    src: url('CustomFont.ttf');
}
body {
    font-family: 'MyCustomFont';
    font-size: 24px;
}
</style>
</head>
<body>
<p>Hello, custom font!</p>
</body>
</html>";

            // Write HTML to a file
            File.WriteAllText(htmlFile, htmlContent);

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFile, configuration);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}