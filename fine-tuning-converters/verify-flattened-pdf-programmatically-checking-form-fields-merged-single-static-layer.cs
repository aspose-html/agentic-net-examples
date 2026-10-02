// Verify flattened PDF by programmatically checking that form fields are merged into a single static layer.

using System;
using System.IO;
using System.Text;
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
            // Prepare sample HTML with a form field
            string htmlContent = @"
                <html>
                    <body>
                        <form>
                            <input type='text' name='sample' value='Test' />
                        </form>
                    </body>
                </html>";

            // Load HTML from string (use two‑argument constructor)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options to flatten form fields
            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "flattened.pdf");

            // Convert HTML to PDF with flattened form fields
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Simple verification: check that the PDF does not contain an AcroForm dictionary
            byte[] pdfBytes = File.ReadAllBytes(outputPath);
            string pdfText = Encoding.UTF8.GetString(pdfBytes);
            bool containsAcroForm = pdfText.Contains("/AcroForm");

            if (containsAcroForm)
            {
                Console.WriteLine("Verification failed: PDF still contains form fields.");
            }
            else
            {
                Console.WriteLine("Verification succeeded: PDF is flattened (no form fields).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}