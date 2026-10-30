// Load an EPUB file from disk and convert it to a GIF using default settings.

using System;

class Program
{
    static void Main()
    {
        System.IO.Stream epubStream = null;
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            epubStream = System.IO.File.OpenRead(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (epubStream != null)
            {
                epubStream.Dispose();
            }
        }
    }
}