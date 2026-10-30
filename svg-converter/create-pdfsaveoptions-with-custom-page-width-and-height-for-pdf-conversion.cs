// Create PdfSaveOptions with custom page width and height for PDF conversion.

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file as source
            string sourcePath = "sample.html";
            System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Hello PDF</h1></body></html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Configure PDF save options with custom page size (8.5 x 11 inches)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);

            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            options.PageSetup.AnyPage = anyPage;

            // Convert HTML to PDF
            string savePath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            System.Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}