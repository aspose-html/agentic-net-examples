// Convert EPUB to TIFF applying a user‑defined CSS file via ImageSaveOptions to control rendering styles.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Services;
using Aspose.Html.Converters;

namespace EpubToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string epubPath = "input.epub";
                string cssPath = "style.css";
                string outputPath = "output.tiff";

                System.IO.Stream stream = System.IO.File.OpenRead(epubPath);
                string cssContent = System.IO.File.ReadAllText(cssPath);
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = cssContent;
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}