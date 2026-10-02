// Convert EPUB to BMP and inject custom stylesheet rules through ImageSaveOptions to modify page appearance.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output_page.bmp";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Configuration configuration = new Configuration();
                IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
                userAgent.UserStyleSheet = "body { background-color: aliceblue; } h1 { color: red; }";

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;
                options.BackgroundColor = Color.AliceBlue;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
                Console.WriteLine($"EPUB converted to BMP at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}