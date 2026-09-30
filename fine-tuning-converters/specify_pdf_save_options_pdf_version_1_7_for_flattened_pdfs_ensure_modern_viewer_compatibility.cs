// Specify PdfSaveOptions.PdfVersion 1.7 when flattening PDFs to ensure compatibility with modern viewers.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file with a form field
            File.WriteAllText(htmlPath, "<html><body><form><input type='text' name='name' value='John Doe'></form></body></html>");

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure PDF save options with flattened form fields
            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF successfully saved to: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}