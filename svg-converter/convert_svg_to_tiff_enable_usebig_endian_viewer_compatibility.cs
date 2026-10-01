// Convert an SVG to TIFF and enable ImageSaveOptions.UseBigEndian for compatibility with certain viewers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG converted to TIFF successfully: {tiffPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}