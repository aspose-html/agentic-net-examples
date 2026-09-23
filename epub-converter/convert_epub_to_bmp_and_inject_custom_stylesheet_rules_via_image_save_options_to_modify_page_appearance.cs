// Convert EPUB to BMP and inject custom stylesheet rules through ImageSaveOptions to modify page appearance.

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure input file exists (create an empty placeholder if not)
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open EPUB stream
            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                // Create configuration and inject custom stylesheet
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.IUserAgentService userAgent = (Aspose.Html.Services.IUserAgentService)configuration.GetService(typeof(Aspose.Html.Services.IUserAgentService));
                userAgent.UserStyleSheet = "body { background-color: lightgray; } h1 { color: darkblue; }";

                // Set image save options for BMP with custom properties
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Convert EPUB to BMP
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, configuration, options, outputPath);
            }

            System.Console.WriteLine("EPUB successfully converted to BMP at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}