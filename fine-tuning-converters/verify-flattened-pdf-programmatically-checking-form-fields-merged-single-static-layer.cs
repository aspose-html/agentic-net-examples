// Verify flattened PDF by programmatically checking that form fields are merged into a single static layer.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a form field
            string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='field1' value='test'></form></body></html>";

            // Load HTML from string (inline content)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options to flatten form fields
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            // Output PDF path
            string outputPath = "flattened.pdf";

            // Convert HTML to PDF with flattened form fields
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Simple verification: check that the PDF does not contain an AcroForm entry
            byte[] pdfBytes = File.ReadAllBytes(outputPath);
            string pdfText = Encoding.UTF8.GetString(pdfBytes);
            bool containsAcroForm = pdfText.Contains("/AcroForm");

            if (containsAcroForm)
                Console.WriteLine("Verification failed: PDF still contains form fields.");
            else
                Console.WriteLine("Verification succeeded: PDF is flattened (no form fields).");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}