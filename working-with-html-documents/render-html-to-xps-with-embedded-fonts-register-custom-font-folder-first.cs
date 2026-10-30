// Render HTML to XPS format with embedded fonts by registering custom font folder first.

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
            // Prepare sample HTML file
            string currentDir = Directory.GetCurrentDirectory();
            string htmlPath = Path.Combine(currentDir, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><p style=\"font-family: 'CustomFont'; font-size:24px;\">Hello, Aspose HTML with custom font!</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Prepare custom fonts folder (ensure it exists)
            string fontsFolder = Path.Combine(currentDir, "fonts");
            Directory.CreateDirectory(fontsFolder);
            // Note: Add your custom font files to the 'fonts' folder as needed.

            // Configure Aspose.HTML with custom fonts lookup folder
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Load HTML document with the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Set XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output XPS file path
            string outputPath = Path.Combine(currentDir, "output.xps");

            // Convert HTML to XPS with embedded fonts
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}