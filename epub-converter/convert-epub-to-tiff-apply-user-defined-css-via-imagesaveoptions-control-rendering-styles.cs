// Convert EPUB to TIFF applying a user‑defined CSS file via ImageSaveOptions to control rendering styles.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string cssPath = "style.css";
            string outputPath = "output.tiff";

            // Create placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Create a simple CSS file if it does not exist
            if (!System.IO.File.Exists(cssPath))
            {
                System.IO.File.WriteAllText(cssPath, "body { background-color: #f0f0f0; }");
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            string cssContent = System.IO.File.ReadAllText(cssPath);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
            userAgent.UserStyleSheet = cssContent;

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);

            stream.Dispose();

            System.Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}