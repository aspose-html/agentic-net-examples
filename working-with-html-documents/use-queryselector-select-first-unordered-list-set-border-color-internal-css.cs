// Use QuerySelector to select the first unordered list and set its border-color using internal CSS.

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><ul><li>Item 1</li><li>Item 2</li></ul></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element ul = document.QuerySelector("ul");
            if (ul != null)
            {
                ul.SetAttribute("style", "border-color:blue;");
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}