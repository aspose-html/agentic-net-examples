// Configure PdfSaveOptions to flatten form fields when converting MHTML to PDF for read‑only documents.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

namespace MhtmlToPdfFlatten
{
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

                // Convert MHTML to PDF with the specified options
                Converter.ConvertMHTML(sourcePath, options, resultPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}