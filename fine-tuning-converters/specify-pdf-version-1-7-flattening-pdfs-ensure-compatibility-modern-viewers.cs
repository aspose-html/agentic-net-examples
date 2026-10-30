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
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            Console.WriteLine("PDF conversion completed: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}