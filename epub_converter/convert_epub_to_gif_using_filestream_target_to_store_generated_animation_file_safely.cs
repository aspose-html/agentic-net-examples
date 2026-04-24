// Convert EPUB to GIF using a FileStream target to store the generated animation file safely.

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
            string epubPath = "input.epub";
            string gifPath = "output.gif";

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertEPUB(epubStream, options, gifPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}