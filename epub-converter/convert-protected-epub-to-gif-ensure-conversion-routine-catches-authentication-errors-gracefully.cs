// Convert a protected EPUB to GIF and ensure the conversion routine catches authentication errors gracefully.

using System;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.epub";
        string outputPath = "sample.gif";

        try
        {
            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                System.Console.WriteLine("Conversion succeeded: " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}