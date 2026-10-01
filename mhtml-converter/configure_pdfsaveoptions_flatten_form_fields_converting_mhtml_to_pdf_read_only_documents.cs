// Configure PdfSaveOptions to flatten form fields when converting MHTML to PDF for read‑only documents.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            if (!System.IO.File.Exists(sourcePath))
            {
                string sampleContent = "<html><body><form><input type='text' name='field' value='test'></form></body></html>";
                System.IO.File.WriteAllText(sourcePath, sampleContent);
            }

            var options = new Aspose.Html.Saving.PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            string resultPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            System.Console.WriteLine("Conversion completed successfully. PDF saved to: " + resultPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}