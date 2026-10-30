// Load an HTML file, set PdfSaveOptions.FormFieldBehaviour to Flattened, and convert to static PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string resultPath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><form><input type='text' name='field' value='test'></form></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, resultPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}