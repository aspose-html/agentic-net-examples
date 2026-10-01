// Create a GIF thumbnail of the first EPUB page by converting a single page and limiting animation frames.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with actual file if needed)
            string inputPath = "sample.epub";
            // Ensure the input file exists (create an empty placeholder if not)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Output GIF thumbnail path
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "thumbnail.gif");

            // Open the EPUB file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Define page size for the thumbnail (e.g., 200x200 pixels)
                var pageSize = new Aspose.Html.Drawing.Size(200, 200);
                var pageMargin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
                var page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
                options.PageSetup.AnyPage = page;

                // Convert the first page of the EPUB to a GIF thumbnail
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            Console.WriteLine("GIF thumbnail created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}