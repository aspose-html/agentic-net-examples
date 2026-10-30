// Specify a custom fonts folder, load HTML with embedded fonts, and render the document to PNG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string fontsFolder = "fonts";
            string fontFile = System.IO.Path.Combine(fontsFolder, "customfont.ttf");
            string htmlFile = "sample.html";
            string outputPath = "output.png";

            // Ensure fonts folder exists and create a dummy font file
            System.IO.Directory.CreateDirectory(fontsFolder);
            if (!System.IO.File.Exists(fontFile))
            {
                System.IO.File.WriteAllBytes(fontFile, new byte[0]);
            }

            // Create sample HTML that uses the custom font
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
<style>
@font-face {
    font-family: 'CustomFont';
    src: url('fonts/customfont.ttf');
}
body {
    font-family: 'CustomFont';
    font-size: 48px;
}
</style>
</head>
<body>Hello, world!</body>
</html>";
            System.IO.File.WriteAllText(htmlFile, htmlContent);

            // Configure Aspose.HTML to use the custom fonts folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Load the HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFile, configuration);

            // Set image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}