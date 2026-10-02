// Set PdfSaveOptions.Title and Author before conversion to embed custom metadata into the flattened PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };
            options.DocumentInfo.Title = "Sample PDF Title";
            options.DocumentInfo.Author = "John Doe";

            string resultPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, resultPath);

            Console.WriteLine($"PDF saved to {resultPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}