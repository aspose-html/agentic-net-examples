// Verify that style changes have been applied by inspecting the style attribute of a target element.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><div id=\"target\">Hello</div></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
                Aspose.Html.Dom.Element element = document.QuerySelector("#target");
                Aspose.Html.HTMLElement target = element as Aspose.Html.HTMLElement;
                if (target == null)
                {
                    System.Console.WriteLine("Target element not found or not an HTMLElement.");
                    return;
                }
                target.Style.BackgroundColor = "red";
                string styleAttr = target.GetAttribute("style");
                System.Console.WriteLine("Style attribute after change: " + styleAttr);
                if (!string.IsNullOrEmpty(styleAttr) && styleAttr.Contains("background-color: red"))
                {
                    System.Console.WriteLine("Style change verified.");
                }
                else
                {
                    System.Console.WriteLine("Style change not applied as expected.");
                }
                string outputPath = "output.html";
                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}