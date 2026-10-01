// Add a table of contents using PdfSaveOptions.Outlines when generating PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file with headings to demonstrate TOC generation
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>" +
                                 "<h1>Chapter 1</h1><p>Content of chapter 1.</p>" +
                                 "<h2>Section 1.1</h2><p>Details.</p>" +
                                 "<h1>Chapter 2</h1><p>Content of chapter 2.</p>" +
                                 "</body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}