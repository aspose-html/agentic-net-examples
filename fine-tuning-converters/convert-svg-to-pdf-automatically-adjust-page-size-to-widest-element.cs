// Convert an SVG file to PDF while automatically adjusting page size to the widest element using AdjustToWidestPage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='300' height='150'><rect width='300' height='150' fill='green'/></svg>";
                System.IO.File.WriteAllText(inputPath, svgContent);
            }

            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.PageSetup.AdjustToWidestPage = true;
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}