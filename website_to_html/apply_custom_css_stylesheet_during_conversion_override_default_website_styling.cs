// Apply a custom CSS stylesheet during conversion to override the default website styling.

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
            // Paths to the input EPUB, custom CSS, and output XPS files
            string epubPath = "input.epub";
            string cssPath = "custom.css";
            string outputPath = "output.xps";

            // Open the EPUB file as a stream
            using (System.IO.Stream epubStream = System.IO.File.OpenRead(epubPath))
            {
                // Read the custom CSS content
                string cssContent = System.IO.File.ReadAllText(cssPath);

                // Create a configuration instance
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                // Retrieve the user agent service to apply the custom stylesheet
                IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = cssContent;

                // Set up XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion with the custom CSS applied
                Converter.ConvertEPUB(epubStream, configuration, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}