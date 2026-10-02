// Append an image element with a data URI source, then convert the document to PDF format.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head><title>Test</title></head><body></body></html>";
            string baseUrl = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Dom.Element img = document.CreateElement("img");
            string dataUri = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=";
            img.SetAttribute("src", dataUri);
            document.Body.AppendChild(img);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("PDF saved to " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}