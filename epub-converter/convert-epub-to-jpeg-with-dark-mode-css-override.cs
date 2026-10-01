// Convert EPUB to JPEG while applying a dark‑mode CSS override via ImageSaveOptions.CssMediaType='screen'.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.epub");
            // Output JPEG file path
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.jpg");

            // Open EPUB file stream
            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                // Create configuration and set dark‑mode CSS override
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = "body { background: #000; color: #fff; }";

                // Set image save options with JPEG format and screen media type
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.Css.MediaType = Aspose.Html.Rendering.MediaType.Screen;

                // Convert EPUB to JPEG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}