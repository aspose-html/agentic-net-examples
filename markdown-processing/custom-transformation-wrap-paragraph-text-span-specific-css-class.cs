// Create a custom transformation that wraps all paragraph text in a span with a specific CSS class.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph with <b>bold</b> text.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.NodeList paragraphs = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement paragraph in paragraphs)
            {
                string original = paragraph.InnerHTML;
                paragraph.InnerHTML = $"<span class=\"highlight\">{original}</span>";
            }
            string outputPath = "transformed.html";
            document.Save(outputPath);
            System.Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}