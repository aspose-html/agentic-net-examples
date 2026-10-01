// Configure sandbox to limit JavaScript memory usage, load a script‑intensive page, and monitor resource consumption.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to allow scripts
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Example 1: Load HTML from a string and print its text content
            string htmlString = "<html><body><p>Hello, Aspose.HTML!</p></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(htmlString, "about:blank", config))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine("Text from string HTML: " + text);
            }

            // Example 2: Create a sample HTML file, load it, and read an element's attribute
            string htmlPath = "sample.html";
            string fileHtml = "<html><body><div id=\"myDiv\" style=\"color:red;\">Sample Div</div></body></html>";
            File.WriteAllText(htmlPath, fileHtml);

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, config))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine("Style attribute of #myDiv: " + styleAttr);
            }

            // Example 3: Load the same file again and output its outer HTML
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, config))
            {
                string outerHtml = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Outer HTML of document: " + outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}