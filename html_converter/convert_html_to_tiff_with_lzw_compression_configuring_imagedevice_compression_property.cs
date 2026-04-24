// Convert HTML to TIFF with LZW compression by configuring ImageDevice compression property.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.tiff";

            HTMLDocument document = new HTMLDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            if (Enum.TryParse<Compression>("Lzw", out var compression))
            {
                options.Compression = compression;
            }

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}