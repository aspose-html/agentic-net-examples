// Export every page of an EPUB as individual BMP images using ImageSaveOptions to control per‑page rendering.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputDir = "output_images";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Stream stream = File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputDir);
            }

            Console.WriteLine("EPUB pages have been exported as BMP images to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}