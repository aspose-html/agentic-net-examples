// Convert an SVG to TIFF and set ImageSaveOptions.DpiX and DpiY to 200 for higher resolution.

using System;

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
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            System.Console.WriteLine("SVG converted to TIFF successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}