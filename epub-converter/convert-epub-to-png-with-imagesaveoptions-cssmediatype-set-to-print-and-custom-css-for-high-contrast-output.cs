// Convert EPUB to PNG with ImageSaveOptions.CssMediaType set to 'print' and custom CSS for high‑contrast output.

namespace AsposeHtmlEpubToPngExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.png";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                    Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));

                    userAgent.UserStyleSheet = "body { background: black !important; color: white !important; }";

                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.Css.MediaType = Aspose.Html.Rendering.MediaType.Print;

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}