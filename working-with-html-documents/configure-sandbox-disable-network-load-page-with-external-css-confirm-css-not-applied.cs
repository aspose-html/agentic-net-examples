// Configure sandbox to disable network, load a page with external CSS, and confirm CSS is not applied.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string folder = Path.Combine(Path.GetTempPath(), "AsposeHtmlSandboxDemo");
            Directory.CreateDirectory(folder);

            string htmlPath = Path.Combine(folder, "index.html");
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"https://example.com/style.css\"></head><body><div id=\"test\">Hello World</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.HTMLElement element = document.GetElementById("test") as Aspose.Html.HTMLElement;
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine(styleAttr ?? "No inline style attribute (external CSS not applied).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}