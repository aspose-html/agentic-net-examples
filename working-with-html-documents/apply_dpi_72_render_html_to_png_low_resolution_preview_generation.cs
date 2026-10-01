// Apply a DPI of 72 when rendering HTML to PNG for low‑resolution preview generation.

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
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Preview</h1></body></html>");
            }

            string outputPath = "preview.png";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}