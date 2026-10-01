// Batch process SVG files to DOCX format, ensuring each document retains vector graphic fidelity after conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(dataDir)) Directory.CreateDirectory(dataDir);
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);

            // Create a simple SVG file
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>SVG</text>
</svg>";
            string svgPath = Path.Combine(dataDir, "sample.svg");
            File.WriteAllText(svgPath, svgContent);

            // Convert SVG file to PDF using file path overload
            string pdfPath1 = Path.Combine(outputDir, "sample_from_file.pdf");
            var pdfOptions1 = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions1, pdfPath1);
            Console.WriteLine($"Converted SVG file to PDF: {pdfPath1}");

            // Convert SVG using SVGDocument object
            string pdfPath2 = Path.Combine(outputDir, "sample_from_document.pdf");
            var pdfOptions2 = new Aspose.Html.Saving.PdfSaveOptions();
            using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, pdfOptions2, pdfPath2);
            }
            Console.WriteLine($"Converted SVG document to PDF: {pdfPath2}");

            // Convert SVG string directly (base URI is empty)
            string pdfPath3 = Path.Combine(outputDir, "sample_from_string.pdf");
            var pdfOptions3 = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, string.Empty, pdfOptions3, pdfPath3);
            Console.WriteLine($"Converted SVG string to PDF: {pdfPath3}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}