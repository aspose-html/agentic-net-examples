// Write a helper that converts MHTML to multiple image formats in a single pass using parallel tasks.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file path
            string inputPath = "sample.mhtml";
            // Ensure the input file exists (create a minimal placeholder if needed)
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            // Output directory
            string outputDir = "output_images";
            Directory.CreateDirectory(outputDir);

            // Define image formats and corresponding file extensions
            (Aspose.Html.Rendering.Image.ImageFormat format, string ext)[] formats = new (Aspose.Html.Rendering.Image.ImageFormat, string)[]
            {
                (Aspose.Html.Rendering.Image.ImageFormat.Jpeg, "jpg"),
                (Aspose.Html.Rendering.Image.ImageFormat.Png, "png"),
                (Aspose.Html.Rendering.Image.ImageFormat.Bmp, "bmp"),
                (Aspose.Html.Rendering.Image.ImageFormat.Tiff, "tiff")
            };

            // Convert MHTML to each image format in parallel
            Parallel.ForEach(formats, fmt =>
            {
                string outputPath = Path.Combine(outputDir, $"output.{fmt.ext}");
                using (Stream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(fmt.format);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                Console.WriteLine($"Converted to {fmt.ext.ToUpperInvariant()} at: {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}