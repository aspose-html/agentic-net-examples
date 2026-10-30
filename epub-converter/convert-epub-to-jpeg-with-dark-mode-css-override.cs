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
            string outputDir = "Output";
            string outputPath = System.IO.Path.Combine(outputDir, "output.jpg");

            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = "body { background: #000; color: #fff; }";

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            System.Console.WriteLine("EPUB converted to JPEG successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}