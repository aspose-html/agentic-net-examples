// Add a configuration flag to enable or disable intermediate HTML file generation during conversion pipelines.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for source markdown, intermediate HTML, and final PDF
            string sourcePath = "input.md";
            string htmlPath = "intermediate.html";
            string pdfPath = "output.pdf";

            // Flag to control generation of intermediate HTML file
            bool generateIntermediate = true;

            if (generateIntermediate)
            {
                // Convert Markdown to HTML and save intermediate file
                Converter.ConvertMarkdown(sourcePath, htmlPath);
            }

            // Load the HTML document (from intermediate file or existing file)
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set PDF conversion options (default settings)
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Convert HTML document to PDF
            Converter.ConvertHTML(document, pdfOptions, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}