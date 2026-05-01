// Create an HTML document, add a meta refresh tag, and test automatic redirection behavior.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument();

            var meta = document.CreateElement("meta");
            meta.SetAttribute("http-equiv", "refresh");
            meta.SetAttribute("content", "5;url=https://example.com");

            var head = (Element)document.GetElementsByTagName("head")[0];
            head.AppendChild(meta);

            string path = "redirect.html";
            document.Save(path);

            var loadedDoc = new Aspose.Html.HTMLDocument(path);
            Console.WriteLine("Document loaded. Title: " + loadedDoc.Title);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}