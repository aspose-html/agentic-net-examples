// Create a document, add a meta description tag, and verify SEO metadata is present after save.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(htmlContent);
            string baseUri = "about:blank";
            string outputPath = "output.html";

            using (var inputStream = new System.IO.MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, baseUri))
            {
                var metaElements = document.GetElementsByTagName("meta");
                bool found = false;
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "This is a sample description.");
                        found = true;
                    }
                }
                if (!found)
                {
                    Aspose.Html.Dom.Element meta = document.CreateElement("meta");
                    meta.SetAttribute("name", "description");
                    meta.SetAttribute("content", "This is a sample description.");
                    Aspose.Html.Dom.Element head = document.GetElementsByTagName("head")[0] as Aspose.Html.Dom.Element;
                    head.AppendChild(meta);
                }

                document.Save(outputPath);
            }

            var savedDoc = new Aspose.Html.HTMLDocument(outputPath);
            var savedMetaElements = savedDoc.GetElementsByTagName("meta");
            bool descriptionExists = false;
            foreach (Aspose.Html.Dom.Element meta in savedMetaElements)
            {
                if (meta.GetAttribute("name") == "description")
                {
                    string content = meta.GetAttribute("content");
                    Console.WriteLine("Meta description found: " + content);
                    descriptionExists = true;
                    break;
                }
            }
            if (!descriptionExists)
            {
                Console.WriteLine("Meta description not found.");
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}