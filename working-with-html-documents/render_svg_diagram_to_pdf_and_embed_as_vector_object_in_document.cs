// Render an SVG diagram to a PDF and embed it as a vector object within the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string baseUri = "http://example.com/";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

            Console.WriteLine("SVG successfully converted to PDF at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}