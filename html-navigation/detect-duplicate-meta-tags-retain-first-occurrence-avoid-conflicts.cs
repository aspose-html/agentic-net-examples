// Detect duplicate meta tags and retain only the first occurrence to avoid conflicts.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head>" +
                "<meta name=\"description\" content=\"First\">" +
                "<meta name=\"keywords\" content=\"sample\">" +
                "<meta name=\"description\" content=\"Duplicate\">" +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">" +
                "<meta http-equiv=\"Content-Type\" content=\"duplicate\">" +
                "</head><body><p>Hello World</p></body></html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var metaElements = document.GetElementsByTagName("meta");

            var metaList = new List<Aspose.Html.Dom.Element>();
            for (int i = 0; i < metaElements.Length; i++)
            {
                metaList.Add((Aspose.Html.Dom.Element)metaElements[i]);
            }

            var seenNames = new HashSet<string>();
            var seenHttpEquiv = new HashSet<string>();

            foreach (var meta in metaList)
            {
                string nameAttr = meta.GetAttribute("name");
                if (!string.IsNullOrEmpty(nameAttr))
                {
                    if (!seenNames.Add(nameAttr))
                    {
                        var parent = meta.ParentNode;
                        if (parent != null) parent.RemoveChild(meta);
                    }
                    continue;
                }

                string httpEquivAttr = meta.GetAttribute("http-equiv");
                if (!string.IsNullOrEmpty(httpEquivAttr))
                {
                    if (!seenHttpEquiv.Add(httpEquivAttr))
                    {
                        var parent = meta.ParentNode;
                        if (parent != null) parent.RemoveChild(meta);
                    }
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}