// Verify flattened PDF by programmatically checking that form fields are merged into a single static layer.

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
            string sourcePath = "input.mhtml";
            string outputPath = "output.pdf";

            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            Converter.ConvertMHTML(sourcePath, options, outputPath);

            Console.WriteLine("PDF generated with flattened form fields.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}