// Convert blockquote sections into italic paragraphs to simplify formatting while retaining emphasis.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><blockquote>Important note.</blockquote><p>Regular paragraph.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            var blockquotes = document.GetElementsByTagName("blockquote");
            var blockquoteList = new List<Aspose.Html.Dom.Element>();
            foreach (Aspose.Html.Dom.Element el in blockquotes)
            {
                blockquoteList.Add(el);
            }

            foreach (var blockquote in blockquoteList)
            {
                string text = blockquote.TextContent;
                Aspose.Html.Dom.Element p = document.CreateElement("p");
                Aspose.Html.Dom.Element i = document.CreateElement("i");
                i.TextContent = text;
                p.AppendChild(i);
                var parent = blockquote.ParentNode;
                parent.ReplaceChild(p, blockquote);
            }

            string outputPath = "output.html";
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