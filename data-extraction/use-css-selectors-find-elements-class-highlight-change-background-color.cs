// Use CSS selectors to find all elements with class "highlight" and change their background color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><style>.highlight { padding:5px; }</style></head><body><p class='highlight'>First</p><div class='highlight'>Second</div><p>No highlight</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll(".highlight");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "yellow";
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