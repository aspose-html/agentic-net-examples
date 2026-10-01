// Merge consecutive list items into a single paragraph to simplify list presentation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "."))
            {
                Aspose.Html.Collections.HTMLCollection uls = document.GetElementsByTagName("ul");
                if (uls.Length > 0)
                {
                    Aspose.Html.HTMLElement ul = uls[0] as Aspose.Html.HTMLElement;
                    if (ul != null)
                    {
                        Aspose.Html.Collections.HTMLCollection lis = ul.GetElementsByTagName("li");
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        for (int i = 0; i < lis.Length; i++)
                        {
                            Aspose.Html.Dom.Element li = lis[i];
                            string text = li.TextContent?.Trim();
                            if (!string.IsNullOrEmpty(text))
                            {
                                if (sb.Length > 0) sb.Append(" ");
                                sb.Append(text);
                            }
                        }

                        Aspose.Html.HTMLElement p = (Aspose.Html.HTMLElement)document.CreateElement("p");
                        p.AppendChild(document.CreateTextNode(sb.ToString()));
                        Aspose.Html.Dom.Node parent = ul.ParentNode;
                        parent.ReplaceChild(p, ul);
                    }
                }

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}