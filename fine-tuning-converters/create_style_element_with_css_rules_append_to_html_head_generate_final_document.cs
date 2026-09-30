// Create a <style> element with CSS rules, append it to the HTML head, and generate the final document.

class Program
{
    static void Main()
    {
        try
        {
            System.String htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            System.String css = "body { background-color: #e5f3fd; } h1 { color: blue; }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }
            head.AppendChild(styleElement);

            System.String outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("HTML document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}