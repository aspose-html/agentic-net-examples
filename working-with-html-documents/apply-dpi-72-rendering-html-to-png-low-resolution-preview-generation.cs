// Apply a DPI of 72 when rendering HTML to PNG for low‑resolution preview generation.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><h1>Hello, Aspose!</h1></body></html>";
                System.IO.File.WriteAllText(htmlPath, sampleHtml);
            }

            // Configure image save options with 72 DPI
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Convert HTML to PNG
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}