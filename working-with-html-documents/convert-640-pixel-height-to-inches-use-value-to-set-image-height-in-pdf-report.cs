// Convert 640 pixel height to inches and use the value to set image height in a PDF report.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 640;
            const double ppi = 96.0;
            double inches = pixels / ppi;
            Console.WriteLine($"Pixel: {pixels} = {inches:F4} inches");

            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Length object: {length}");

            string base64Png = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=";
            string htmlContent = $"<html><body><img id='img' src='data:image/png;base64,{base64Png}' style='height:{inches}in;'></body></html>";

            string htmlPath = "report.html";
            File.WriteAllText(htmlPath, htmlContent);

            string pdfPath = "report.pdf";
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);

            Console.WriteLine($"PDF report generated at {pdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}