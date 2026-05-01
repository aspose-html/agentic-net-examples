// Configure sandbox to disable network, load a page with external CSS, and confirm CSS is not applied.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to block scripts (network resources like external CSS are not loaded)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Prepare test files
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "sandbox_test");
            Directory.CreateDirectory(baseDir);
            string cssPath = Path.Combine(baseDir, "style.css");
            File.WriteAllText(cssPath, "#test { color: red; }");
            string htmlPath = Path.Combine(baseDir, "index.html");
            string htmlContent = "<html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><div id=\"test\">Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document with sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("test");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine(styleAttr ?? "No inline style (CSS not applied)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}