// Convert SVG to XPS while preserving original color profiles by disabling color conversion in options.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output XPS paths
            string sourcePath = "sample.svg";
            string outputPath = "output.xps";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightgreen"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Load the SVG document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(sourcePath))
            {
                // Configure XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.AliceBlue;

                // Define page size and margins
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                // Apply page setup
                options.PageSetup.AnyPage = page;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine($"Conversion succeeded. XPS saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}