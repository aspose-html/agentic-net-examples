// Convert an EPUB file to XPS and embed custom CSS during conversion using XpsSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string cssPath = "custom.css";
            string outputPath = "output.xps";

            // Read custom CSS content
            string cssContent = File.ReadAllText(cssPath);

            // Create configuration and set the user style sheet
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContent;

            // Set XPS save options (optional customizations can be added here)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Open EPUB file stream and perform conversion
            using (Stream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to XPS with custom CSS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}