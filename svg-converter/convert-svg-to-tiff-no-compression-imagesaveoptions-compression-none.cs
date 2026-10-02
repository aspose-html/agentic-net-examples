// Convert an SVG to TIFF with no compression by setting ImageSaveOptions.Compression to None.

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
                System.IO.File.WriteAllText(svgPath, "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>");
            }

            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            Console.WriteLine("SVG successfully converted to TIFF with no compression.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}