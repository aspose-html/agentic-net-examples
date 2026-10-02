// Merge consecutive list items into a single paragraph to simplify list presentation.

using System;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul></body></html>";
            var doc = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Collections.HTMLCollection uls = doc.GetElementsByTagName("ul");
            for (int i = uls.Length - 1; i >= 0; i--)
            {
                Aspose.Html.HTMLElement ul = uls[i] as Aspose.Html.HTMLElement;
                if (ul == null) continue;

                Aspose.Html.Collections.HTMLCollection lis = ul.GetElementsByTagName("li");
                if (lis.Length == 0) continue;

                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < lis.Length; j++)
                {
                    Aspose.Html.HTMLElement li = lis[j] as Aspose.Html.HTMLElement;
                    if (li == null) continue;

                    string text = li.TextContent?.Trim();
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (sb.Length > 0) sb.Append(" ");
                        sb.Append(text);
                    }
                }

                Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)doc.CreateElement("p");
                p.AppendChild(doc.CreateTextNode(sb.ToString()));

                var parent = ul.ParentNode;
                if (parent != null)
                {
                    parent.ReplaceChild(p, ul);
                }
            }

            string outputPath = "output.html";
            doc.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}