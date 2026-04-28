// Retrieve the value of the viewport meta tag to determine mobile rendering settings.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            var meta = document.QuerySelector("meta[name=viewport]") as Element;
            if (meta != null)
            {
                string content = meta.GetAttribute("content");
                Console.WriteLine("Viewport meta content: " + content);
            }
            else
            {
                Console.WriteLine("Viewport meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}