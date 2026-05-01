// Convert 640 pixel height to inches and use the value to set image height in a PDF report.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 640;
            const double ppi = 96.0;
            double inches = pixels / ppi;
            Length heightLength = Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, Inches: {inches:F4}");

            string htmlContent = $"<html><body><img src='sample.png' style='height:{inches}in;'/></body></html>";

            PdfSaveOptions options = new PdfSaveOptions();
            string outputPath = "report.pdf";

            Converter.ConvertHTML(htmlContent, "", options, outputPath);
            Console.WriteLine($"PDF report generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}