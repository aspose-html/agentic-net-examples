// Embed fonts in PdfSaveOptions during SVG to PDF conversion for consistent text appearance.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><text x='10' y='50' font-family='Arial' font-size='24'>Hello</text></svg>";
            string baseUri = "about:blank";
            string outputPath = "output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, baseUri, options, outputPath);

            Console.WriteLine("SVG converted to PDF successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}