// Set PdfSaveOptions.Title and Author before conversion to embed custom metadata into the flattened PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='name' value='John Doe'></form></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}