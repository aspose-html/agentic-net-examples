// Use HTMLDocument.CreateElement to create a style element, append to head, and define a text color rule.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "p { color: red; }";
            Aspose.Html.Dom.Element head = System.Linq.Enumerable.First(document.GetElementsByTagName("head"));
            head.AppendChild(style);
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}