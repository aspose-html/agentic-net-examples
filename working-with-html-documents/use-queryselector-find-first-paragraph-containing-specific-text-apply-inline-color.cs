// Use QuerySelector to find the first paragraph containing specific text and apply inline color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p>First paragraph</p><p>Target paragraph with keyword</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");
            Aspose.Html.HTMLElement target = null;
            for (int i = 0; i < paragraphs.Length; i++)
            {
                var elem = paragraphs[i] as Aspose.Html.HTMLElement;
                if (elem != null && elem.TextContent != null && elem.TextContent.Contains("keyword"))
                {
                    target = elem;
                    break;
                }
            }

            if (target != null)
            {
                target.SetAttribute("style", "color:rgb(50,150,200);");
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