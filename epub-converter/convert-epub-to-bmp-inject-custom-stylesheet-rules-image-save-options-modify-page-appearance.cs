// Convert EPUB to BMP and inject custom stylesheet rules through ImageSaveOptions to modify page appearance.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Services;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Open EPUB file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create configuration and inject custom stylesheet
                Configuration configuration = new Configuration();
                IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = "body { background-color: aliceblue; }";

                // Set image save options for BMP with custom appearance
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;
                options.BackgroundColor = Color.AliceBlue;
                options.Css.MediaType = MediaType.Print;

                // Convert EPUB to BMP
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}