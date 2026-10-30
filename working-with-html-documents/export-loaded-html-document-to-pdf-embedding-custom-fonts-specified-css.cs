// Export a loaded HTML document to PDF while embedding custom fonts specified in CSS.

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
            string inputPath = "sample.html";
            string outputPath = "output.pdf";
            string fontsFolder = "fonts";

            // Ensure fonts folder exists
            if (!Directory.Exists(fontsFolder))
            {
                Directory.CreateDirectory(fontsFolder);
            }

            // Create a minimal HTML file with a custom font reference
            if (!File.Exists(inputPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'CustomFont';
    src: url('fonts/CustomFont.ttf');
}
body {
    font-family: 'CustomFont', sans-serif;
    font-size: 24px;
}
</style>
</head>
<body>
<p>This text should use the custom embedded font.</p>
</body>
</html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            userAgentService.FontsSettings.SetFontsLookupFolder(Path.GetFullPath(fontsFolder));

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}