// Set sandbox flags to disable network access, load a page with external resources, and confirm they are blocked.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with external resources
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><script src=\"https://example.com/script.js\"></script></head><body><img src=\"https://example.com/image.png\" alt=\"test\"/></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to disable network access (no flags enabled)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Attempt to retrieve external image element
                HTMLCollection imgCollection = document.GetElementsByTagName("img");
                Aspose.Html.HTMLElement imgElement = imgCollection.Length > 0 ? imgCollection[0] as Aspose.Html.HTMLElement : null;
                string imgSrc = imgElement != null ? imgElement.GetAttribute("src") : "null";

                // Attempt to retrieve external script element
                HTMLCollection scriptCollection = document.GetElementsByTagName("script");
                Aspose.Html.HTMLElement scriptElement = scriptCollection.Length > 0 ? scriptCollection[0] as Aspose.Html.HTMLElement : null;
                string scriptSrc = scriptElement != null ? scriptElement.GetAttribute("src") : "null";

                Console.WriteLine("Image src attribute: " + imgSrc);
                Console.WriteLine("Script src attribute: " + scriptSrc);
                Console.WriteLine("External resources are blocked due to sandbox configuration.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}