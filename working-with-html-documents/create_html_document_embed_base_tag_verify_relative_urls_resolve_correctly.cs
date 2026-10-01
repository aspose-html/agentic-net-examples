// Create an HTML document, embed a base tag, and verify relative URLs resolve correctly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><base href=\"https://example.com/subdir/\"/></head><body><a href=\"page.html\">Link</a><img src=\"image.png\"/></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            string outputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            document.Save(outputPath);

            Aspose.Html.Collections.HTMLCollection anchorCollection = document.GetElementsByTagName("a");
            if (anchorCollection.Length > 0)
            {
                Aspose.Html.Dom.Element anchorElement = anchorCollection[0];
                string href = anchorElement.GetAttribute("href");
                Aspose.Html.Url resolvedHref = new Aspose.Html.Url(href, document.BaseURI);
                Console.WriteLine("Resolved anchor URL: " + resolvedHref);
            }

            Aspose.Html.Collections.HTMLCollection imageCollection = document.GetElementsByTagName("img");
            if (imageCollection.Length > 0)
            {
                Aspose.Html.Dom.Element imageElement = imageCollection[0];
                string src = imageElement.GetAttribute("src");
                Aspose.Html.Url resolvedSrc = new Aspose.Html.Url(src, document.BaseURI);
                Console.WriteLine("Resolved image URL: " + resolvedSrc);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}