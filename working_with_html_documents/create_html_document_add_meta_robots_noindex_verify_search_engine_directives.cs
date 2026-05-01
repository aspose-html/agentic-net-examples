// Create an HTML document, add a meta robots tag with noindex, and verify search engine directives.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            string baseUri = "http://example.com/";
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Create <meta name=\"robots\" content=\"noindex\">
            var meta = document.CreateElement("meta");
            meta.SetAttribute("name", "robots");
            meta.SetAttribute("content", "noindex");

            // Append meta to <head>
            var heads = document.GetElementsByTagName("head");
            if (heads.Length > 0)
            {
                var head = (Aspose.Html.Dom.Element)heads[0];
                head.AppendChild(meta);
            }

            // Verify the meta tag
            var metas = document.GetElementsByTagName("meta");
            for (int i = 0; i < metas.Length; i++)
            {
                var element = (Aspose.Html.Dom.Element)metas[i];
                if (element.GetAttribute("name") == "robots")
                {
                    Console.WriteLine($"Meta robots directive: {element.GetAttribute("content")}");
                }
            }

            // Save the document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}