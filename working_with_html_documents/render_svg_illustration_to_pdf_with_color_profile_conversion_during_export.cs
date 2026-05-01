// Render an SVG illustration to PDF and apply a color profile conversion during export.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string pdfPath = "output.pdf";

            PdfSaveOptions options = new PdfSaveOptions();

            Converter.ConvertSVG(svgPath, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}