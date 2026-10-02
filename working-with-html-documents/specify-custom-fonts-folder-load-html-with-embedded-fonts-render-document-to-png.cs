// Specify a custom fonts folder, load HTML with embedded fonts, and render the document to PNG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string fontsFolder = "fonts";
            string outputPath = "output.png";

            // Ensure fonts folder exists and contains a placeholder font file
            Directory.CreateDirectory(fontsFolder);
            string fontFilePath = Path.Combine(fontsFolder, "SampleFont.ttf");
            if (!File.Exists(fontFilePath))
            {
                File.WriteAllBytes(fontFilePath, new byte[0]);
            }

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(Path.GetFullPath(fontsFolder), true);

            // HTML content that uses the embedded font
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'SampleFont';
    src: url('SampleFont.ttf');
}
body {
    font-family: 'SampleFont';
    font-size: 48px;
}
</style>
</head>
<body>Hello, world!</body>
</html>";

            // Base URI for resolving relative font URL
            string baseUri = new Uri(Path.GetFullPath(fontsFolder) + Path.DirectorySeparatorChar).AbsoluteUri;

            // Load HTML document with configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, configuration);

            // Set image save options for PNG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}