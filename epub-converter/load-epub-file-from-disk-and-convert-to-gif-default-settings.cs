// Load an EPUB file from disk and convert it to a GIF using default settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}