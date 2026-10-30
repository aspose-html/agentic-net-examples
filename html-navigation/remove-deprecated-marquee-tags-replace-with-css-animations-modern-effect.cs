// Remove all deprecated <marquee> tags and replace them with CSS animations for modern effect.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Test</title></head><body><marquee>Scrolling Text</marquee></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = @"
.marquee-replacement {
    overflow: hidden;
    white-space: nowrap;
    display: inline-block;
    animation: marquee 5s linear infinite;
}
@keyframes marquee {
    from { transform: translateX(100%); }
    to { transform: translateX(-100%); }
}";
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.QuerySelector("head");
            if (head != null)
            {
                head.AppendChild(style);
            }
            else
            {
                Aspose.Html.Dom.Element newHead = document.CreateElement("head");
                newHead.AppendChild(style);
                Aspose.Html.Dom.Element html = (Aspose.Html.Dom.Element)document.QuerySelector("html");
                if (html != null)
                {
                    html.InsertBefore(newHead, html.FirstChild);
                }
            }

            Aspose.Html.Collections.NodeList marquees = document.QuerySelectorAll("marquee");
            for (int i = 0; i < marquees.Length; i++)
            {
                Aspose.Html.Dom.Element marquee = (Aspose.Html.Dom.Element)marquees[i];
                string text = ((Aspose.Html.HTMLElement)marquee).TextContent;

                Aspose.Html.Dom.Element span = document.CreateElement("span");
                span.SetAttribute("class", "marquee-replacement");
                ((Aspose.Html.HTMLElement)span).TextContent = text;

                marquee.ParentNode.ReplaceChild(span, marquee);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}