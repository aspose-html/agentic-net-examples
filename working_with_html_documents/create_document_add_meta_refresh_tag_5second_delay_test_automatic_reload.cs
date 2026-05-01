// Create a document, add a meta refresh tag with 5‑second delay, and test automatic reload.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            using (HTMLDocument document = new HTMLDocument())
            {
                var meta = document.CreateElement("meta");
                meta.SetAttribute("http-equiv", "refresh");
                meta.SetAttribute("content", "5");

                var head = (HTMLElement)document.GetElementsByTagName("head")[0];
                head.AppendChild(meta);

                string outputPath = "meta_refresh.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}. Open it in a browser to test automatic reload.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}