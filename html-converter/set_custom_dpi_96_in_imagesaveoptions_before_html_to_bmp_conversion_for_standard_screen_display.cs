// Set custom DPI of 96 in ImageSaveOptions before converting HTML to BMP for standard screen display.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.bmp";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, World!</h1></body></html>");
            }

            string htmlContent = System.IO.File.ReadAllText(htmlPath);
            string baseUri = new System.Uri(System.IO.Path.GetFullPath(htmlPath)).AbsoluteUri;

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}