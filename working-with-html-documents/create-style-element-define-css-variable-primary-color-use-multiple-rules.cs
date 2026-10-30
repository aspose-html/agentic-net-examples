// Create a style element, define a CSS variable for primary color, and use it in multiple rules.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = ":root { --primary-color: #3498db; } .box { background-color: var(--primary-color); color: white; padding: 10px; } .text { color: var(--primary-color); }";

            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

            Aspose.Html.HTMLElement box = (Aspose.Html.HTMLElement)document.CreateElement("div");
            box.ClassName = "box";
            box.TextContent = "Box with primary color background";

            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.CreateElement("p");
            paragraph.ClassName = "text";
            paragraph.TextContent = "Text using primary color";

            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            body.AppendChild(box);
            body.AppendChild(paragraph);

            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("HTML document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}