// Set PdfSaveOptions.Title and Author before conversion to embed custom metadata into the flattened PDF.

using System;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
                var document = new Aspose.Html.HTMLDocument(htmlContent, ".");
                var options = new Aspose.Html.Saving.PdfSaveOptions();
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
}