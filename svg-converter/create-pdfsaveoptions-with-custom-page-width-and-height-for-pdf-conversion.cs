// Create PdfSaveOptions with custom page width and height for PDF conversion.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.html";
                string savePath = "output.pdf";

                if (!System.IO.File.Exists(sourcePath))
                {
                    System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, PDF!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromInches(8.5f), Aspose.Html.Drawing.Length.FromInches(11f));
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                System.Console.WriteLine("PDF saved to " + savePath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}