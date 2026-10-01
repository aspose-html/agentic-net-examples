// Transform MHTML content into a high‑resolution PNG image using ImageSaveOptions with DPI settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                string html = "<html><body><h1>Hello MHTML</h1></body></html>";
                File.WriteAllText(inputPath, html);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.UseAntialiasing = true;

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