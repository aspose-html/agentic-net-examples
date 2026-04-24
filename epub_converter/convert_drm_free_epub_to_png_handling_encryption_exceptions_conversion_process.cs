// Convert a DRM‑free EPUB to PNG while handling potential encryption exceptions during the conversion process.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}