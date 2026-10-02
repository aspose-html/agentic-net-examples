// Load an MHTML document, configure PdfSaveOptions to Flattened, and convert it to a non‑interactive PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define source MHTML file path and create a minimal sample if it does not exist
            string sourcePath = "sample.mhtml";
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Sample MHTML</h1></body></html>");
            }

            // Define output PDF file path
            string resultPath = "output.pdf";

            // Configure PDF save options to flatten form fields (non‑interactive PDF)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            // Convert MHTML to PDF
            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}