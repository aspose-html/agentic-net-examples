// Split an HTML document into separate files at each top‑level heading for modular publishing.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1");
                if (headings.Length == 0)
                    continue;

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement heading = (Aspose.Html.HTMLElement)headings[i];

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<!DOCTYPE html>");
                    sb.AppendLine("<html><head><meta charset=\"utf-8\"/></head><body>");

                    sb.AppendLine(heading.OuterHTML);

                    var sibling = heading.NextSibling;
                    while (sibling != null && !(sibling is Aspose.Html.HTMLElement el && el.TagName.Equals("h1", StringComparison.OrdinalIgnoreCase)))
                    {
                        if (sibling is Aspose.Html.HTMLElement elNode)
                        {
                            sb.AppendLine(elNode.OuterHTML);
                        }
                        else if (sibling is Aspose.Html.Dom.Text textNode)
                        {
                            sb.AppendLine(textNode.TextContent);
                        }
                        sibling = sibling.NextSibling;
                    }

                    sb.AppendLine("</body></html>");

                    string safeTitle = Regex.Replace(heading.TextContent.Trim(), @"\s+", "_");
                    foreach (char c in Path.GetInvalidFileNameChars())
                    {
                        safeTitle = safeTitle.Replace(c.ToString(), string.Empty);
                    }

                    string outFileName = Path.GetFileNameWithoutExtension(htmlPath) + "_" + safeTitle + ".html";
                    string outPath = Path.Combine(outputFolder, outFileName);
                    File.WriteAllText(outPath, sb.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}