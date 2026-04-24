// Cache downloaded external SVG files locally to avoid redundant network requests.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving.ResourceHandlers;

namespace SvgCacheExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string svgUrl = "https://example.com/sample.svg";
                string outputDirectory = "cached_svg";

                Directory.CreateDirectory(outputDirectory);

                using (SVGDocument doc = new SVGDocument(svgUrl))
                {
                    doc.Save(new FileSystemResourceHandler(outputDirectory));
                }

                Console.WriteLine("SVG and its external resources have been cached successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}