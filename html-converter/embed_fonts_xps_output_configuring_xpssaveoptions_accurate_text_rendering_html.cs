// Embed fonts in XPS output by configuring XpsSaveOptions for accurate text rendering from HTML.

using System;
using System.IO;

namespace AsposeHtmlXpsExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML content with a custom font reference
                string html = "<!DOCTYPE html><html><head><style>@font-face {font-family: 'MyFont'; src: url('https://example.com/font.ttf'); } body {font-family: 'MyFont';}</style></head><body><p>Hello, world with custom font!</p></body></html>";

                // Create configuration and set the fonts lookup folder
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                Aspose.Html.Services.IUserAgentService userAgent = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
                userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

                // Load HTML document with the configuration
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, configuration);

                // Define output XPS file path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

                // Configure XPS save options (default options embed fonts automatically when available)
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert HTML to XPS
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("XPS file saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}