// Set ImageSaveOptions DPI to 300 for high‑resolution PNG printing applications.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create ImageSaveOptions and set DPI to 300 for high‑resolution PNG
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Example conversion of an HTML file to PNG using the configured options
            string htmlPath = "input.html";
            string outputPath = "output.png";
            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}