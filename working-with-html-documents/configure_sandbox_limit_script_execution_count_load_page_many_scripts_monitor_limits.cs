// Configure sandbox to limit script execution count, load a page with many scripts, and monitor limits.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Load HTML from a string with sandbox configuration
            var config1 = new Aspose.Html.Configuration();
            config1.Security |= Aspose.Html.Sandbox.Scripts;

            string htmlString = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(htmlString, "", config1))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine("Text from string document: " + text);
            }

            // Create a temporary HTML file with an element that has an id and style attribute
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            string fileHtmlContent = "<!DOCTYPE html><html><head><title>File Sample</title></head><body><div id=\"myDiv\" style=\"color:red;\">Sample Div</div></body></html>";
            File.WriteAllText(tempFilePath, fileHtmlContent);

            var config2 = new Aspose.Html.Configuration();
            config2.Security |= Aspose.Html.Sandbox.Scripts;

            using (var docFromFile = new Aspose.Html.HTMLDocument(tempFilePath, config2))
            {
                var element = docFromFile.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine("Style attribute from file document: " + styleAttr);
            }

            // Load the same file and output its outer HTML
            var config3 = new Aspose.Html.Configuration();
            config3.Security |= Aspose.Html.Sandbox.Scripts;

            using (var docOuter = new Aspose.Html.HTMLDocument(tempFilePath, config3))
            {
                string output = docOuter.DocumentElement != null ? docOuter.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("OuterHTML from file document: " + output);
            }

            // Load HTML from the file path again and print its text content
            var config4 = new Aspose.Html.Configuration();
            config4.Security |= Aspose.Html.Sandbox.Scripts;

            using (var docPath = new Aspose.Html.HTMLDocument(tempFilePath, config4))
            {
                string text = docPath.DocumentElement != null ? docPath.DocumentElement.TextContent : string.Empty;
                Console.WriteLine("Text from path document: " + text);
            }

            // Clean up temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}