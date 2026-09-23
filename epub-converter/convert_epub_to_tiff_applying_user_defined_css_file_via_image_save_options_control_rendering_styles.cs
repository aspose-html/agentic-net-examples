// Convert EPUB to TIFF applying a user‑defined CSS file via ImageSaveOptions to control rendering styles.

using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string epubPath = "sample.epub";
                string cssPath = "style.css";
                string outputPath = "output.tiff";

                // Create minimal sample files if they do not exist
                if (!File.Exists(epubPath))
                {
                    File.WriteAllBytes(epubPath, new byte[0]);
                }
                if (!File.Exists(cssPath))
                {
                    File.WriteAllText(cssPath, "body { background: #fff; }");
                }

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string cssContent = File.ReadAllText(cssPath);

                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                    userAgent.UserStyleSheet = cssContent;

                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

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
}