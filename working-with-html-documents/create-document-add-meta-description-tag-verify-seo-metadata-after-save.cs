// Create a document, add a meta description tag, and verify SEO metadata is present after save.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, "about:blank"))
            {
                var metaElements = document.GetElementsByTagName("meta");
                bool descriptionFound = false;
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "Sample description for SEO");
                        descriptionFound = true;
                        break;
                    }
                }
                if (!descriptionFound)
                {
                    Aspose.Html.Dom.Element meta = document.CreateElement("meta");
                    meta.SetAttribute("name", "description");
                    meta.SetAttribute("content", "Sample description for SEO");
                    var heads = document.GetElementsByTagName("head");
                    if (heads.Length > 0)
                    {
                        Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)heads[0];
                        head.AppendChild(meta);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
            }

            using (var verifyDoc = new Aspose.Html.HTMLDocument("output.html"))
            {
                var metas = verifyDoc.GetElementsByTagName("meta");
                bool hasDescription = false;
                foreach (Aspose.Html.Dom.Element meta in metas)
                {
                    if (meta.GetAttribute("name") == "description" && !string.IsNullOrWhiteSpace(meta.GetAttribute("content")))
                    {
                        hasDescription = true;
                        break;
                    }
                }
                Console.WriteLine(hasDescription ? "SEO meta description is present." : "SEO meta description is missing.");
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}