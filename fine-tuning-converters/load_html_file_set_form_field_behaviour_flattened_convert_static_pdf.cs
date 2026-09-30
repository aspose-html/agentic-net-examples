// Load an HTML file, set PdfSaveOptions.FormFieldBehaviour to Flattened, and convert to static PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><form><input type='text' name='name' value='John Doe'></form></body></html>");
            }

            string resultPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, resultPath);

            Console.WriteLine("PDF saved to " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}