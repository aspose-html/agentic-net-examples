// Use CSS selectors to find all bold text elements and replace their inner HTML with uppercase text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>This is <b>bold</b> and <strong>strong</strong> text.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("b, strong");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string inner = element.InnerHTML;
                element.InnerHTML = inner.ToUpperInvariant();
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}