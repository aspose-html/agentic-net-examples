// Dispose of HtmlDocument and PdfSaveOptions objects after each conversion to free unmanaged resources promptly.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

                Converter.ConvertHTML(document, options, outputPath);

                options = null; // release reference for GC
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}