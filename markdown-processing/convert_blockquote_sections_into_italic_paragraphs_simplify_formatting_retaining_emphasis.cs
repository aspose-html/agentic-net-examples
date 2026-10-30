// Convert blockquote sections into italic paragraphs to simplify formatting while retaining emphasis.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Sample</title></head><body><blockquote>Quote 1</blockquote><p>Normal paragraph.</p><blockquote>Quote 2</blockquote></body></html>";
            string tempHtmlPath = Path.GetTempFileName();
            File.WriteAllText(tempHtmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempHtmlPath);

            var blockquoteList = new List<Aspose.Html.Dom.Element>();
            foreach (Aspose.Html.Dom.Element el in document.GetElementsByTagName("blockquote"))
            {
                blockquoteList.Add(el);
            }

            foreach (Aspose.Html.Dom.Element blockquote in blockquoteList)
            {
                Aspose.Html.Dom.Element p = document.CreateElement("p");
                Aspose.Html.Dom.Element i = document.CreateElement("i");
                i.TextContent = blockquote.TextContent;
                p.AppendChild(i);
                Aspose.Html.Dom.Node parent = blockquote.ParentNode;
                parent.ReplaceChild(p, blockquote);
            }

            string outputPath = Path.Combine(Path.GetDirectoryName(tempHtmlPath), "output.html");
            document.Save(outputPath);
            Console.WriteLine(document.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}