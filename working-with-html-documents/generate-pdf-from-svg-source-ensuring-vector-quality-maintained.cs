// Generate a PDF from an SVG source, ensuring vector quality is maintained during conversion.

using System;
using System.IO;

namespace SvgToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.svg";
                string outputPath = "output.pdf";

                if (!File.Exists(sourcePath))
                {
                    string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";
                    File.WriteAllText(sourcePath, svgContent);
                }

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

                Console.WriteLine("SVG has been successfully converted to PDF: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}