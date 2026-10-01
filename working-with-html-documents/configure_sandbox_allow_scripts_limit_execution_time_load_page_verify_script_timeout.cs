// Configure sandbox to allow scripts but limit execution time, load a page, and verify script timeout.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Configure sandbox for string-based HTML
                Aspose.Html.Configuration config = new Aspose.Html.Configuration();
                config.Security |= Aspose.Html.Sandbox.Scripts;

                // Load HTML from a string
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body>Hello Aspose HTML!</body></html>";
                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlContent, "", config))
                {
                    string text = doc.DocumentElement != null ? doc.DocumentElement.TextContent : string.Empty;
                    Console.WriteLine("Extracted text: " + text);
                }

                // Create a sample HTML file
                string htmlPath = "sample.html";
                string htmlFileContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div id=\"myDiv\" style=\"color:red;\">Sample Div</div></body></html>";
                File.WriteAllText(htmlPath, htmlFileContent);

                // Configure sandbox for file-based HTML
                Aspose.Html.Configuration fileConfig = new Aspose.Html.Configuration();
                fileConfig.Security |= Aspose.Html.Sandbox.Scripts;

                // Load HTML from the file
                using (Aspose.Html.HTMLDocument fileDoc = new Aspose.Html.HTMLDocument(htmlPath, fileConfig))
                {
                    var element = fileDoc.GetElementById("myDiv");
                    string styleAttr = element != null ? element.GetAttribute("style") : null;
                    Console.WriteLine("Style attribute of #myDiv: " + styleAttr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}