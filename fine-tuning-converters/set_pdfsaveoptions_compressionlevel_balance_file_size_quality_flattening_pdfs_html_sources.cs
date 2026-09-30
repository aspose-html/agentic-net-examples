// Set PdfSaveOptions.CompressionLevel to balance file size and quality when flattening PDFs from HTML sources.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><form><input type='text' name='name' value='John'></form></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            var options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;
            // CompressionLevel property is not available in the current API version.

            string outputPath = "flattened_output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}