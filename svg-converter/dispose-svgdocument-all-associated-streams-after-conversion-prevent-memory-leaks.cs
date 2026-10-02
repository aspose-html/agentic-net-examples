// Dispose SVGDocument and all associated streams after conversion to prevent memory leaks.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        string inputPath = "sample.svg";
        string outputPath = "output.pdf";

        // Create a minimal SVG file if it does not exist
        if (!File.Exists(inputPath))
        {
            string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
</svg>";
            File.WriteAllText(inputPath, svgContent, Encoding.UTF8);
        }

        try
        {
            using (SVGDocument document = new SVGDocument(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine("SVG conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}