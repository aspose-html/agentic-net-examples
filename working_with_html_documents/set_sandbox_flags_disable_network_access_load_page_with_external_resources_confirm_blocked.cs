// Set sandbox flags to disable network access, load a page with external resources, and confirm they are blocked.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "test.html";
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"https://example.com/style.css\"></head><body><img id=\"img\" src=\"https://example.com/image.png\" /><script src=\"https://example.com/script.js\"></script></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var img = document.GetElementById("img");
                string src = img != null ? img.GetAttribute("src") : "null";
                Console.WriteLine("Image src attribute: " + src);
                string outerHtml = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}