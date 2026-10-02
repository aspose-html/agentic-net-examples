// Configure PdfSaveOptions to flatten form fields when converting MHTML to PDF for read‑only documents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string resultPath = "result.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}