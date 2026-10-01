// Replace deprecated <font> tags with equivalent CSS style attributes throughout the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>This is <font color=\"red\" size=\"4\" face=\"Arial\">sample</font> text.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            var fontElements = document.GetElementsByTagName("font");
            var fontsList = new System.Collections.Generic.List<Aspose.Html.Dom.Element>();
            foreach (Aspose.Html.Dom.Element el in fontElements)
            {
                fontsList.Add(el);
            }

            foreach (Aspose.Html.Dom.Element el in fontsList)
            {
                Aspose.Html.HTMLElement font = (Aspose.Html.HTMLElement)el;

                string style = "";
                string color = font.GetAttribute("color");
                if (!string.IsNullOrEmpty(color))
                {
                    style += $"color:{color};";
                }
                string size = font.GetAttribute("size");
                if (!string.IsNullOrEmpty(size))
                {
                    style += $"font-size:{size}px;";
                }
                string face = font.GetAttribute("face");
                if (!string.IsNullOrEmpty(face))
                {
                    style += $"font-family:{face};";
                }

                Aspose.Html.Dom.Element span = document.CreateElement("span");
                ((Aspose.Html.HTMLElement)span).SetAttribute("style", style);
                ((Aspose.Html.HTMLElement)span).InnerHTML = font.InnerHTML;

                font.ParentNode.ReplaceChild(span, font);
            }

            document.Save("output.html");
            Console.WriteLine("Font tags replaced and saved to output.html");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}