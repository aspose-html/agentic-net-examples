// Configure sandbox to allow images, disable scripts, load a page, and verify only images appear.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src=\"https://example.com/image.png\" alt=\"Sample Image\" /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox: allow images, disable scripts
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security = Aspose.Html.Sandbox.Images; // only images are permitted

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify that images are present
                Aspose.Html.Collections.HTMLCollection images = document.Images;
                Console.WriteLine($"Number of images found: {images.Length}");

                // Verify that no script elements are present
                Aspose.Html.Collections.HTMLCollection scripts = document.GetElementsByTagName("script");
                Console.WriteLine($"Number of script elements found: {scripts.Length}");

                // Additional check: ensure all top-level child nodes in body are images
                bool onlyImagesInBody = true;
                Aspose.Html.Dom.Element body = document.Body;
                for (int i = 0; i < body.ChildNodes.Length; i++)
                {
                    Aspose.Html.Dom.Node node = body.ChildNodes[i];
                    if (node.NodeType == Aspose.Html.Dom.Node.ELEMENT_NODE)
                    {
                        Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)node;
                        if (!string.Equals(element.TagName, "IMG", StringComparison.OrdinalIgnoreCase))
                        {
                            onlyImagesInBody = false;
                            break;
                        }
                    }
                }
                Console.WriteLine($"Only images appear in body: {onlyImagesInBody}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}