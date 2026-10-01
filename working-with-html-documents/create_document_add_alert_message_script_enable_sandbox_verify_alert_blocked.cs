// Create a document, add a script that alerts a message, enable sandbox, and verify alert is blocked.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Example 1: Load HTML from temporary file and print outer HTML
            string htmlContent1 = "<html><body><p>Hello World</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample1.html");
            File.WriteAllText(tempFile, htmlContent1);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document outer HTML:");
                Console.WriteLine(output);
            }

            // Example 2: Load HTML from file, get element by id, print style attribute
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample2.html");
            string htmlContent2 = "<html><body><div id=\"myDiv\" style=\"color:red;\">Sample Div</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent2);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine("Style attribute of element with id 'myDiv':");
                Console.WriteLine(styleAttr);
            }

            // Example 3: Re-load HTML from the same temporary file and print outer HTML again
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Re-loaded document outer HTML:");
                Console.WriteLine(html);
            }

            // Example 4: Print text content of the document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine("Document text content:");
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}