// Define custom page size of A4 in ImageSaveOptions before converting HTML to PDF for standard documents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.27f),
                Aspose.Html.Drawing.Length.FromInches(11.69f));

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}