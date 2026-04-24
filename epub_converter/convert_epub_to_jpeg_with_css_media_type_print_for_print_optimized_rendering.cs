// Convert EPUB to JPEG with ImageSaveOptions.CssMediaType set to 'print' for print‑optimized rendering.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.jpg";

            Stream stream = File.OpenRead(epubPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.Css.MediaType = MediaType.Print;

            Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}