// Set image DPI in ImageSaveOptions to 150 for PNG output to balance quality and file size.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            string outputPath = "output.png";
            string htmlContent = System.IO.File.ReadAllText(htmlPath);
            string baseUri = new System.Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}