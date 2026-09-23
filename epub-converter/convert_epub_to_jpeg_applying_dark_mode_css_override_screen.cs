// Convert EPUB to JPEG while applying a dark‑mode CSS override via ImageSaveOptions.CssMediaType='screen'.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.jpg";

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = "body { background: #000; color: #fff; }";

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}