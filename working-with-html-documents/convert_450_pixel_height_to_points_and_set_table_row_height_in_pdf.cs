// Convert 450 pixel height to points and use the result to set table row height in PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 450;
            double heightPoints = heightPixels * 72.0 / 96.0;

            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            string htmlContent = $"<html><body><table border='1'><tr style='height:{heightPoints:F2}pt;'><td>Row with height {heightPoints:F2}pt</td></tr></table></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}