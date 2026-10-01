// Create a command‑line utility that accepts EPUB input path and GIF output path as arguments.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "sample.epub";
            string outputPath = args.Length > 1 ? args[1] : "output.gif";

            // Ensure the input file exists; if not, create an empty placeholder file.
            if (!File.Exists(inputPath))
            {
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // Write minimal content to avoid zero-byte file (optional).
                }
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                // Optional: set resolution
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}