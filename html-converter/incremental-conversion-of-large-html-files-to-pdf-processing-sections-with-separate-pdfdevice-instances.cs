// Perform incremental conversion of large HTML files to PDF by processing sections with separate PdfDevice instances.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML sections
            string htmlSection1 = "<html><body><h1>Section 1</h1><p>Content of the first part.</p></body></html>";
            string htmlSection2 = "<html><body><h1>Section 2</h1><p>Content of the second part.</p></body></html>";
            string htmlSection3 = "<html><body><h1>Section 3</h1><p>Content of the third part.</p></body></html>";

            // Output PDF files for each section
            string outputPdf1 = Path.Combine(Directory.GetCurrentDirectory(), "Section1.pdf");
            string outputPdf2 = Path.Combine(Directory.GetCurrentDirectory(), "Section2.pdf");
            string outputPdf3 = Path.Combine(Directory.GetCurrentDirectory(), "Section3.pdf");

            // Convert each HTML section to PDF using separate PdfDevice instances
            ConvertSectionToPdf(htmlSection1, outputPdf1);
            ConvertSectionToPdf(htmlSection2, outputPdf2);
            ConvertSectionToPdf(htmlSection3, outputPdf3);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ConvertSectionToPdf(string htmlContent, string outputPath)
    {
        // Load HTML from string (using a base URI placeholder)
        Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

        // Set PDF rendering options if needed
        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

        // Create a PDF device that writes directly to the file
        using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
        {
            // Render the document to the PDF device
            document.RenderTo(device);
        }

        // Alternatively, you can use the Converter API:
        // Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
    }
}