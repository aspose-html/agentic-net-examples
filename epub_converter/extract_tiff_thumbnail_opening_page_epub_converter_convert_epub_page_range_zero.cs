// Extract a TIFF thumbnail of the opening page from an EPUB using Converter.ConvertEPUB with page range set to zero.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            using (Stream stream = File.OpenRead("input.epub"))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                Converter.ConvertEPUB(stream, options, "thumbnail.tiff");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}