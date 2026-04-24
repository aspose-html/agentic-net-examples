// Convert EPUB to PNG with ImageSaveOptions.CssMediaType set to 'print' and custom CSS for high‑contrast output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.png";
            string highContrastCss = "body { background: black; color: white; }";

            Stream stream = File.OpenRead(inputPath);
            Configuration configuration = new Configuration();
            IUserAgentService userAgent = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgent.UserStyleSheet = highContrastCss;

            ImageSaveOptions options = new ImageSaveOptions();
            options.Css.MediaType = MediaType.Print;

            Converter.ConvertEPUB(stream, configuration, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}