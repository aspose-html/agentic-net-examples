// Open the resulting PDF and confirm that interactive form fields are no longer editable, indicating successful flattening.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

namespace FlattenPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file containing form fields
                string sourcePath = "input.html";

                // Path where the flattened PDF will be saved
                string resultPath = "output.pdf";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(sourcePath);

                // Prepare PDF save options with form fields flattened
                PdfSaveOptions options = new PdfSaveOptions();
                options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

                // Convert HTML to PDF using the configured options
                Converter.ConvertHTML(document, options, resultPath);

                // Note: Verification of form field editability would require additional PDF processing
                // which is not covered by the available Aspose.HTML rules.
                Console.WriteLine("Conversion completed. The PDF has been saved to: " + resultPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}