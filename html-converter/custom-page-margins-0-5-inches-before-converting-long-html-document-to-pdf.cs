// Set custom page margins of 0.5 inches in PdfSaveOptions before converting a long HTML document to PDF.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Sample Document</h1><p>This is a long document.</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5),
                Aspose.Html.Drawing.Length.FromInches(0.5));

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            Console.WriteLine("PDF saved to " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}