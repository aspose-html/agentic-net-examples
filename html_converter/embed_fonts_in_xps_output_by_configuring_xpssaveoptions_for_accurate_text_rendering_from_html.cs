// Embed fonts in XPS output by configuring XpsSaveOptions for accurate text rendering from HTML.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Path to the folder containing custom fonts
            string fontsFolder = "fonts";
            // Path for the output XPS file
            string outputPath = "output.xps";

            // Create a configuration object
            Configuration configuration = new Configuration();

            // Retrieve the user agent service to set the fonts lookup folder
            IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgent.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Load the HTML document with the configured settings
            HTMLDocument document = new HTMLDocument(htmlPath, configuration);

            // Create XPS save options (default settings)
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert the HTML document to XPS, embedding the fonts
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}