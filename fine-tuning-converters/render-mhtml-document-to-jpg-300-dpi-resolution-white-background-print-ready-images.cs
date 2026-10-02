// Render an MHTML document to JPG with 300 DPI resolution and white background for print‑ready images.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string simpleHtml = "<html><body><h1>Sample MHTML</h1></body></html>";
                File.WriteAllText(inputPath, simpleHtml);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}