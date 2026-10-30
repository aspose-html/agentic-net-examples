// Add a table of contents using PdfSaveOptions.Outlines when generating PDF.

using System;

namespace AsposeHtmlPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample Document</title></head><body><h1>Chapter 1</h1><p>Some content here.</p><h2>Section 1.1</h2><p>More content.</p></body></html>";
                string baseUri = "about:blank";

                // Load HTML from string
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

                // Configure PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

                // Note: PdfSaveOptions.Outlines is not available in the current API, so a table of contents cannot be set via this property.

                // Convert HTML to PDF
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("PDF successfully saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}