// Adjust ImageSaveOptions gamma value to improve brightness for PNG conversion.

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
            // Prepare input MHTML file (sample content)
            string inputPath = "sample.mht";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Prepare output PNG file path
            string outputPath = "output.png";

            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for PNG
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath("output.png"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}