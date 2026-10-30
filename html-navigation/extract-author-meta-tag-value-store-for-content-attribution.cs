// Extract the value of the author meta tag and store it for content attribution.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"author\" content=\"John Doe\"><title>Sample</title></head><body><p>Hello</p></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");
                string author = null;
                for (int i = 0; i < metaElements.Length; i++)
                {
                    Aspose.Html.Dom.Element meta = (Aspose.Html.Dom.Element)metaElements[i];
                    if (meta.GetAttribute("name") == "author")
                    {
                        author = meta.GetAttribute("content");
                        break;
                    }
                }
                Console.WriteLine("Author: " + (author ?? "Not found"));
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}