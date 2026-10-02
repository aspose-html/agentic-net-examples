// Load an HTML file, set PdfSaveOptions.FormFieldBehaviour to Flattened, and convert to static PDF.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "input.html";
            string resultPath = "output.pdf";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><body><form><input type='text' name='field' value='test'></form></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, resultPath);

            System.Console.WriteLine("PDF saved to " + resultPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}