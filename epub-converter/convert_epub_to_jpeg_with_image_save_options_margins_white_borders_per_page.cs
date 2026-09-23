// Convert EPUB to JPEG while configuring ImageSaveOptions.Margins to add white borders around each page.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "page.jpg");

            if (!File.Exists(inputFile))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(inputFile, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputFile))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.BackgroundColor = Color.White;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1200),
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}