// Add a table of contents using PdfSaveOptions.Outlines when generating PDF.

using System;
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
            // Input HTML file path
            string inputHtmlPath = "input.html";
            // Output PDF file path
            string outputPdfPath = "output.pdf";

            // Prepare PDF save options (flatten form fields as an example)
            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Convert HTML to PDF using the prepared options
            Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}