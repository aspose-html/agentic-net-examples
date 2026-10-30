// Apply a custom CSS stylesheet during conversion to override the default website styling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string cssPath = "custom.css";
            string outputPath = "output.xps";

            // Create sample HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Create sample CSS file if it does not exist
            if (!File.Exists(cssPath))
            {
                string cssContent = "h1 { color: red; }";
                File.WriteAllText(cssPath, cssContent);
            }

            // Load custom CSS
            string cssContentLoaded = File.ReadAllText(cssPath);

            // Configure Aspose.HTML with custom user stylesheet
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContentLoaded;

            // Set XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, configuration, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}