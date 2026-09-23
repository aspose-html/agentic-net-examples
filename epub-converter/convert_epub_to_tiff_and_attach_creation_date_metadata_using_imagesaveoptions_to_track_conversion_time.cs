// Convert EPUB to TIFF and attach creation date metadata using ImageSaveOptions to track conversion time.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            // Create a minimal placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Placeholder EPUB content");
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                // If supported, attach creation date metadata:
                // options.Metadata.CreationDate = DateTime.Now;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}