// Apply a custom color profile in ImageSaveOptions while exporting MHTML to PNG for color‑critical workflows.

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
            string inputPath = "input.mhtml";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                // If a custom color profile is supported, set it here
                // options.ColorProfile = new ColorProfile("custom.icc");
                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}