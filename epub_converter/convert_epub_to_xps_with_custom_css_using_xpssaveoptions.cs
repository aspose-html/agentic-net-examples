// Convert an EPUB file to XPS and embed custom CSS during conversion using XpsSaveOptions.

using System;
using System.IO;
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
            // Paths to the input EPUB, custom CSS file, and the output XPS file
            string epubPath = "sample.epub";
            string cssPath = "custom.css";
            string outputPath = "output.xps";

            // Open the EPUB file as a read‑only stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Load custom CSS content
                string cssContent = File.ReadAllText(cssPath);

                // Create a configuration instance to hold services
                Configuration configuration = new Configuration();

                // Retrieve the user‑agent service and assign the custom stylesheet
                var userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = cssContent;

                // Initialize XPS save options (default settings)
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion: EPUB -> XPS with custom CSS applied
                Converter.ConvertEPUB(epubStream, configuration, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS with custom CSS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}