// Set sandbox flags to disable both scripts and images, load a complex page, and verify content.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing a script and an image
            string htmlContent = "<!DOCTYPE html><html><head><script>console.log('test');</script></head><body><img src='https://example.com/image.png' id='testImg' /><div id='content'>Hello World</div></body></html>";
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow scripts and images (valid flags)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            configuration.Security |= Aspose.Html.Sandbox.Images;

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify image element attribute
                var imgElement = (Aspose.Html.Dom.Element)document.GetElementById("testImg");
                string imgSrc = imgElement != null ? imgElement.GetAttribute("src") : "null";
                Console.WriteLine("Image src attribute: " + imgSrc);

                // Verify text content of a div
                var divElement = (Aspose.Html.Dom.Element)document.GetElementById("content");
                string divText = divElement != null ? divElement.TextContent : "null";
                Console.WriteLine("Div text: " + divText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}