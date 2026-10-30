// Add a comment node describing style changes before the style element in the head section.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var headCollection = document.GetElementsByTagName("head");
            var head = headCollection[0] as Aspose.Html.HTMLElement;
            var style = document.CreateElement("style") as Aspose.Html.HTMLElement;
            style.TextContent = "body { background-color: #e5f3fd; }";
            var comment = document.CreateComment("Added style to set background color");
            head.InsertBefore(comment, style);
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