// Adjust ImageSaveOptions gamma value to improve brightness for PNG conversion.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                options.UseAntialiasing = true;
                // Gamma adjustment is not supported by ImageSaveOptions; omitted.
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}