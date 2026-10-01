// Apply a custom CSS stylesheet during conversion to override the default website styling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (minimal placeholder if not present)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create an empty file as a placeholder; conversion will fail gracefully if invalid
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Prepare a simple CSS file for the user style sheet
            string cssPath = "style.css";
            if (!File.Exists(cssPath))
            {
                File.WriteAllText(cssPath, "body { font-family: Arial; }");
            }

            // Open the EPUB file as a stream
            Stream stream = File.OpenRead(inputPath);

            // Create Aspose.Html configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get the user agent service and set a custom style sheet
            Aspose.Html.Services.IUserAgentService userAgent =
                (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

            string cssContent = File.ReadAllText(cssPath);
            userAgent.UserStyleSheet = cssContent;

            // Set XPS save options (default options are sufficient for this example)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Define output path
            string outputPath = "output.xps";

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}