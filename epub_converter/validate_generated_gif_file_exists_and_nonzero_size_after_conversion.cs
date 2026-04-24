// Validate that the generated GIF file exists and has a non-zero file size after conversion.

using System;
using System.IO;
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
            string inputPath = "input.html";
            string outputPath = "output.gif";

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            Converter.ConvertHTML(document, options, outputPath);

            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
            {
                Console.WriteLine("GIF generated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to generate GIF.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}