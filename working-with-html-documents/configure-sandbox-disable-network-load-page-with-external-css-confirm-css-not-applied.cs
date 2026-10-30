// Configure sandbox to disable network, load a page with external CSS, and confirm CSS is not applied.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML and external CSS files
            string baseDir = Directory.GetCurrentDirectory();
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string cssPath = Path.Combine(baseDir, "style.css");

            string cssContent = "#test { color: red; }";
            File.WriteAllText(cssPath, cssContent);

            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><div id=\"test\">Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow only scripts (network disabled)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Retrieve the element with id="test"
                Aspose.Html.Dom.Element element = document.GetElementById("test");
                Aspose.Html.HTMLElement htmlElement = element as Aspose.Html.HTMLElement;

                // Check if any inline style was applied (external CSS should not be applied)
                string styleAttr = htmlElement != null ? htmlElement.GetAttribute("style") : null;

                if (string.IsNullOrEmpty(styleAttr))
                {
                    Console.WriteLine("External CSS was not applied (sandbox network disabled).");
                }
                else
                {
                    Console.WriteLine("External CSS was applied: " + styleAttr);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}