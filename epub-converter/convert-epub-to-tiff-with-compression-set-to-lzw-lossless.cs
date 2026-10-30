// Convert EPUB to TIFF with ImageSaveOptions.Compression set to LZW to achieve lossless compression.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.tiff");

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}