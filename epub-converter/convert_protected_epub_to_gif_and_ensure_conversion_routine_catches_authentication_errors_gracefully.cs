// Convert a protected EPUB to GIF and ensure the conversion routine catches authentication errors gracefully.

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
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Create a dummy EPUB file if it does not exist (for demonstration purposes)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message != null && ex.Message.IndexOf("authentication", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("Authentication error: " + ex.Message);
            }
            else
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}