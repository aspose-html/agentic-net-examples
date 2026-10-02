// Specify PdfSaveOptions.PdfVersion 1.7 when flattening PDFs to ensure compatibility with modern viewers.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><form><input type='text' name='name' value='John Doe'></form></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}