// Load an HTML file, set PdfSaveOptions.FormFieldBehaviour to Flattened, and convert to static PDF.

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
            // Path to the source HTML file
            string sourcePath = "input.html";
            // Path where the resulting PDF will be saved
            string outputPath = "output.pdf";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Create PDF save options and set form fields to be flattened (static)
            PdfSaveOptions options = new PdfSaveOptions();
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Convert the HTML document to a PDF with the specified options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}