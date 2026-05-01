// Create a command‑line tool that accepts an input HTML path and outputs a PNG with specified DPI.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: <inputHtmlPath> <outputPngPath> <dpi>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            int dpi = int.Parse(args[2]);

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = dpi;
            options.VerticalResolution = dpi;

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}