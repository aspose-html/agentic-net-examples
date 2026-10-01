// Create a custom transformation that wraps all paragraph text in a span with a specific CSS class.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second <b>bold</b> paragraph.</p></body></html>";
            string baseUri = "http://example.com/";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string original = element.InnerHTML;
                element.InnerHTML = "<span class=\"myClass\">" + original + "</span>";
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}