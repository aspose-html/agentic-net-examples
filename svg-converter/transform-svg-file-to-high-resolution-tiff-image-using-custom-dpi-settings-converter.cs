// Transform an SVG file into a high‑resolution TIFF image using custom DPI settings in the converter.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string svgPath = "sample.svg";
                string tiffPath = "output.tiff";

                if (!System.IO.File.Exists(svgPath))
                {
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                    System.IO.File.WriteAllText(svgPath, svgContent);
                }

                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

                Console.WriteLine("SVG converted to high-resolution TIFF successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}