// Preserve original meta tags and SEO attributes when converting website pages to HTML.

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
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Sample page\"><meta name=\"keywords\" content=\"Aspose,HTML\"><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            {
                using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
                {
                    var metaElements = document.GetElementsByTagName("meta");
                    foreach (Aspose.Html.Dom.Element meta in metaElements)
                    {
                        // Preserve SEO attributes; ensure 'content' attribute is retained
                        string content = meta.GetAttribute("content");
                        if (string.IsNullOrEmpty(content))
                        {
                            meta.SetAttribute("content", "default");
                        }
                    }

                    string outputPath = "output.html";
                    document.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}