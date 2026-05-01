// Configure custom fonts folder, load HTML using @font-face rules, and verify fonts render correctly.

using System;
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
            // Path to the folder that contains custom fonts
            string fontsFolder = @"C:\CustomFonts";

            // Path to the HTML file that uses @font-face rules
            string htmlFilePath = @"C:\HtmlSamples\sample.html";

            // Path where the rendered image will be saved
            string outputImagePath = @"C:\HtmlSamples\output.png";

            // Create a configuration object to hold rendering settings
            Configuration configuration = new Configuration();

            // Retrieve the user agent service from the configuration
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));

            // Configure the fonts lookup folder (recursive search enabled)
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder, true);

            // Load the HTML document using the configured configuration
            HTMLDocument document = new HTMLDocument(htmlFilePath, configuration);

            // Define image saving options (default settings)
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert the HTML document to an image file
            Converter.ConvertHTML(document, options, outputImagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}