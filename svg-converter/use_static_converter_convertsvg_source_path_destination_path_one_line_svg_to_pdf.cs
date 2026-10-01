// Use static Converter.ConvertSVG(sourcePath, destinationPath) for one‑line SVG to PDF conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string svgCode = "<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><rect width='200' height='200' style='fill:rgb(0,0,255);stroke-width:3;stroke:rgb(0,0,0)'/></svg>";

            var options = new Aspose.Html.Saving.PdfSaveOptions();

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, options, outputPath);

            Console.WriteLine($"SVG successfully converted to PDF at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}