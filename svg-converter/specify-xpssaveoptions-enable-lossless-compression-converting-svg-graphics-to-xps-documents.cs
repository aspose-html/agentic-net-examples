// Specify XpsSaveOptions to enable lossless compression when converting SVG graphics to XPS documents.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath,
                    "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                    "<rect width='200' height='200' fill='red'/>" +
                    "</svg>");
            }

            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine("SVG has been successfully converted to XPS.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}