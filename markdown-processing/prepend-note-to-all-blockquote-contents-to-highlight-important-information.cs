// Prepend the word “NOTE:” to all blockquote contents to highlight important information.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello Aspose.HTML!</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var style = document.CreateElement("style");
            style.TextContent = "p { color: red; }";
            var head = System.Linq.Enumerable.First(document.GetElementsByTagName("head"));
            head.AppendChild(style);
            document.Save("output.html");
            System.Console.WriteLine("HTML document saved to output.html");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}