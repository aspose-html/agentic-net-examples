// Convert EPUB to PNG and define a transparent background using ImageSaveOptions.BackgroundColor set to transparent.

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
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.png");

            // Ensure the input file exists; for demonstration purposes, you should place a valid EPUB file at the specified location.
            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.BackgroundColor = Color.Transparent;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}