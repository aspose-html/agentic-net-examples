// Export every page of an EPUB as individual BMP images using ImageSaveOptions to control per‑page rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output_images";

            Directory.CreateDirectory(outputDir);

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputDir);
            }

            Console.WriteLine("EPUB pages have been exported as BMP images to: " + Path.GetFullPath(outputDir));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}