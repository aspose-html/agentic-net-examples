// Configure PdfSaveOptions to flatten form fields when converting MHTML to PDF for read‑only documents.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            string resultPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}