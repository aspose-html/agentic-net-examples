// Convert EPUB to BMP and inject custom stylesheet rules through ImageSaveOptions to modify page appearance.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Services;
using Aspose.Html.Rendering;

namespace EpubToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input EPUB file path
                string epubPath = "sample.epub";
                // Output BMP file path
                string outputPath = "output.bmp";

                // Open EPUB as a stream
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Create configuration to inject custom stylesheet
                    Configuration config = new Configuration();
                    var userAgent = (IUserAgentService)config.GetService(typeof(IUserAgentService));
                    // Custom CSS to modify page appearance
                    userAgent.UserStyleSheet = "body { background-color: aliceblue; }";

                    // Create image save options for BMP format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                    // Optional rendering settings
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 400;
                    options.VerticalResolution = 400;
                    // Apply CSS media type if needed
                    options.Css.MediaType = MediaType.Print;

                    // Convert EPUB to BMP with custom options
                    Converter.ConvertEPUB(epubStream, config, options, outputPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}