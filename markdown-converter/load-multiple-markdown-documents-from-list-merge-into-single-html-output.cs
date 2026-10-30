// Load multiple Markdown documents from a list and merge them into a single HTML output file.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            var markdownList = new List<string>
            {
                "# Title 1\n\nThis is the first markdown document.",
                "## Title 2\n\nThis is the second markdown document."
            };

            var mergedDoc = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><head></head><body></body></html>", "about:blank");
            var mergedBody = mergedDoc.QuerySelector("body") as Aspose.Html.HTMLBodyElement;
            if (mergedBody == null)
            {
                mergedBody = mergedDoc.CreateElement("body") as Aspose.Html.HTMLBodyElement;
                mergedDoc.DocumentElement.AppendChild(mergedBody);
            }

            foreach (var md in markdownList)
            {
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(md));
                var doc = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");
                var body = doc.QuerySelector("body") as Aspose.Html.HTMLBodyElement;
                if (body != null)
                {
                    var sourceHtml = body as Aspose.Html.HTMLElement;
                    var targetHtml = mergedBody as Aspose.Html.HTMLElement;
                    targetHtml.InnerHTML += sourceHtml.InnerHTML;
                }
            }

            string outputPath = "merged.html";
            mergedDoc.Save(outputPath);
            Console.WriteLine(mergedDoc.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}