// Add a hover state style rule for links that changes text color when the mouse is over.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head></head><body><a href='https://example.com'>Example Link</a></body></html>";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "a:hover { color: red; }";
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(style);
            document.Save(outputPath);
            Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}