// Clone a navigation menu element and insert the clone at the end of the body.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><nav id=\"mainNav\"><ul><li>Home</li><li>About</li></ul></nav></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var nav = document.QuerySelector("nav") as Aspose.Html.HTMLElement;
            if (nav == null)
            {
                Console.WriteLine("Navigation element not found.");
                return;
            }

            var clone = document.CreateElement("nav") as Aspose.Html.HTMLElement;
            clone.InnerHTML = nav.InnerHTML;

            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.AppendChild(clone);

            var options = new Aspose.Html.Saving.HTMLSaveOptions();
            string outputPath = "output.html";
            document.Save(outputPath, options);

            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}