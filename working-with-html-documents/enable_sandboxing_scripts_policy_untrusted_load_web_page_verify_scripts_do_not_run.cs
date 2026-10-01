// Enable sandboxing with ScriptsPolicy.Untrusted, load a web page, and verify scripts do not run.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><body><div id='myDiv' style='color:red;'>Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load document with sandbox configuration
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine(styleAttr);
            }

            // Load the same document again and print outer HTML
            using (var document2 = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string html = document2.DocumentElement != null ? document2.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }

            // Load again and print outer HTML (demonstrating another usage)
            using (var document3 = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string html = document3.DocumentElement != null ? document3.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }

            // Load again and print text content
            using (var document4 = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string text = document4.DocumentElement != null ? document4.DocumentElement.TextContent : string.Empty;
                Console.WriteLine(text);
            }

            // Create a second sample HTML file and load it
            string htmlContent2 = "<html><body><p>Sample paragraph</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample2.html");
            File.WriteAllText(tempFile, htmlContent2);

            using (var document5 = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = document5.DocumentElement != null ? document5.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}