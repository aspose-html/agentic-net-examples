// Specify PdfSaveOptions.PdfVersion 1.7 when flattening PDFs to ensure compatibility with modern viewers.

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
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;
            // PdfVersion property is not available in the current API; omitted.

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}