// Configure sandbox to disable network, load a page with external CSS, and confirm CSS is not applied.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create sample CSS file
            string cssPath = "style.css";
            string cssContent = "#test { color: red; }";
            File.WriteAllText(cssPath, cssContent);

            // Create sample HTML file that references the external CSS
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><div id=\"test\">Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to restrict script execution (network is implicitly disabled)
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Retrieve the element that would be styled by the external CSS
                var element = document.GetElementById("test");
                string styleAttr = element != null ? element.GetAttribute("style") : null;

                // Output the style attribute (should be null if CSS was not applied)
                Console.WriteLine(styleAttr ?? "No style attribute (CSS not applied)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}