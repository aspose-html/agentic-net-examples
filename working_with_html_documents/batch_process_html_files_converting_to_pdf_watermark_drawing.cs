// Batch process HTML files, converting each to PDF with a watermark added via drawing API.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "html_input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "pdf_output");
            Directory.CreateDirectory(outputDir);

            // Process each HTML file in the input directory
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath, Path.GetDirectoryName(htmlPath)))
                {
                    // Create a watermark element
                    Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:40%; left:20%; font-size:48px; color:rgba(255,0,0,0.3); transform:rotate(-45deg); pointer-events:none;");
                    div.TextContent = "CONFIDENTIAL";

                    // Append the watermark to the body
                    document.Body.AppendChild(div);

                    // Prepare PDF conversion options
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Define output PDF path
                    string pdfFileName = Path.GetFileNameWithoutExtension(htmlPath) + ".pdf";
                    string pdfPath = Path.Combine(outputDir, pdfFileName);

                    // Convert HTML document to PDF
                    Converter.ConvertHTML(document, options, pdfPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}