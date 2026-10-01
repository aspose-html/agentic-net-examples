// Load an SVG from a local path and convert it to XPS with custom page dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            if (!File.Exists(sourcePath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightgreen"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
  <text x=""100"" y=""115"" font-size=""30"" text-anchor=""middle"" fill=""white"">SVG</text>
</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Load SVG document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
            {
                // Configure XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Define page size and margins
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                options.PageSetup.AnyPage = page;

                // Convert SVG to XPS
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output file: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}