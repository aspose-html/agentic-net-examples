// Use CSS selectors to find all bold text elements and replace their inner HTML with uppercase text.

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><body><p>This is <b>bold</b> and <strong>strong</strong> text.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("b, strong");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.InnerHTML = element.InnerHTML.ToUpperInvariant();
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