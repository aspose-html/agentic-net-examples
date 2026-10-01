// Create an HTML document, add a meta charset UTF‑8, and verify correct encoding on load.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body>Hello World</body></html>";
            string baseUri = "file:///";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(outputPath);

            string sourcePath = outputPath;
            string readHtml = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding("utf-8"));
            Aspose.Html.HTMLDocument loadedDoc = new Aspose.Html.HTMLDocument(readHtml, baseUri);

            var metaElements = loadedDoc.GetElementsByTagName("meta");
            foreach (Aspose.Html.Dom.Element meta in metaElements)
            {
                string charset = meta.GetAttribute("charset");
                if (!string.IsNullOrEmpty(charset))
                {
                    System.Console.WriteLine("Charset meta found: " + charset);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}