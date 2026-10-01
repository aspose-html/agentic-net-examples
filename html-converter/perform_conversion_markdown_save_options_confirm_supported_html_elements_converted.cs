// Perform conversion with default MarkdownSaveOptions and confirm that all supported HTML elements are converted.

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading</h1><p>This is a <strong>paragraph</strong> with <a href=\"https://example.com\">link</a>.</p><ul><li>Item 1</li><li>Item 2</li></ul><ol><li>First</li><li>Second</li></ol><table><tr><th>Header</th></tr><tr><td>Cell</td></tr></table><img src=\"https://via.placeholder.com/150\" alt=\"Sample Image\"/></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);
            string savePath = "output.md";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);
            System.Console.WriteLine("Conversion completed. Markdown saved to " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}