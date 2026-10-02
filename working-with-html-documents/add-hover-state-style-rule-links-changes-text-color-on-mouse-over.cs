// Add a hover state style rule for links that changes text color when the mouse is over.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><a href=\"#\">Sample Link</a></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "a:hover { color: red; }";
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
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