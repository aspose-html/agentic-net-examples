// Load an SVG document from a stream using a MemoryStream.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string baseUri = "about:blank";
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

            Console.WriteLine("SVG saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}