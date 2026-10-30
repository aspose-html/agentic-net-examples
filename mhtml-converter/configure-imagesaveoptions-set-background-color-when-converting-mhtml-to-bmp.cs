// Configure ImageSaveOptions to set background color when converting MHTML to BMP format.

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
            string inputPath = "sample.mht";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <test@example.com>\nSubject: Test\n\n<html><body><p>Hello</p></body></html>";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            Stream stream = File.OpenRead(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.BackgroundColor = Color.Beige;
            // options.HorizontalResolution = 96;
            // options.VerticalResolution = 96;

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}