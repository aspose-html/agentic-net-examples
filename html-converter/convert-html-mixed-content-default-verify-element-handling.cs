// Convert HTML with mixed content using default options to verify comprehensive element handling.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>" +
                "<h1>Header</h1>" +
                "<p>This is a paragraph with <strong>bold</strong> text.</p>" +
                "<img src='data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAocB9W6XK6cAAAAASUVORK5CYII=' alt='pixel'/>" +
                "<table border='1'><tr><th>Col1</th><th>Col2</th></tr><tr><td>Data1</td><td>Data2</td></tr></table>" +
                "<form><input type='text' name='name' value='test'/><input type='checkbox' checked/></form>" +
                "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            string outputPath = "output.xps";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}