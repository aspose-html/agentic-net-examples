// Load an MHTML document, configure PdfSaveOptions to Flattened, and convert it to a non‑interactive PDF.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string sourcePath = "input.mhtml";

            // Configure PDF save options to flatten form fields
            PdfSaveOptions options = new PdfSaveOptions
            {
                FormFieldBehaviour = FormFieldBehaviour.Flattened
            };

            // Path for the resulting PDF file
            string resultPath = "output.pdf";

            // Perform the conversion from MHTML to a non‑interactive PDF
            Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}