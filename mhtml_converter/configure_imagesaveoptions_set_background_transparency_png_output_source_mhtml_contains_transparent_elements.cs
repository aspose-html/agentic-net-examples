// Configure ImageSaveOptions to set background transparency for PNG output when source MHTML contains transparent elements.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source MHTML file and the desired PNG output
            string inputPath = "input.mhtml";
            string outputPath = "output.png";

            // Open the MHTML file as a readable stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create ImageSaveOptions with PNG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                // Set background to transparent to preserve transparency from the source
                options.BackgroundColor = Color.Transparent;

                // Convert the MHTML stream to PNG using the configured options
                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}