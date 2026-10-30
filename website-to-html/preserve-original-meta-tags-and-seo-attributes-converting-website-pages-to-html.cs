// Preserve original meta tags and SEO attributes when converting website pages to HTML.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Sample page description\"><meta name=\"keywords\" content=\"sample,html\"><title>Sample Page</title></head><body><h1>Hello World</h1></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        // Preserve the original content attribute (no change)
                        meta.SetAttribute("content", meta.GetAttribute("content"));
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                System.Console.WriteLine("HTML saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}