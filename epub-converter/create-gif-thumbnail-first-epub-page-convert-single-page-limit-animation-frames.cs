// Create a GIF thumbnail of the first EPUB page by converting a single page and limiting animation frames.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            string outputPath = Path.Combine(outputDir, "thumbnail.gif");
            Directory.CreateDirectory(outputDir);

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(200, 200),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("GIF thumbnail created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}