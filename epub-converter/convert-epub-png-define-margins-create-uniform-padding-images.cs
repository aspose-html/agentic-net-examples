// Convert EPUB to PNG and define ImageSaveOptions.Margins to create uniform padding for images.

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output paths
            string dataDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data");
            System.IO.Directory.CreateDirectory(dataDir);
            string inputPath = System.IO.Path.Combine(dataDir, "sample.epub");
            // Create a placeholder EPUB file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }
            string outputDir = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Output");
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "output.png");

            // Open the EPUB file stream
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                // Configure image save options with PNG format and uniform margins
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;
                options.BackgroundColor = System.Drawing.Color.White;

                // Define a page with desired size and uniform padding (10 pixels on each side)
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
                options.PageSetup.AnyPage = page;

                // Perform the conversion from EPUB to PNG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}