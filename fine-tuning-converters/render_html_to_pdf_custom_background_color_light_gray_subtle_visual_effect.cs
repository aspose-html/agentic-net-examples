// Render HTML to PDF with custom background color set to light gray for subtle visual effect.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string pdfPath = "output.pdf";

                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.BackgroundColor = System.Drawing.Color.LightGray;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                System.Console.WriteLine("PDF saved to " + pdfPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}