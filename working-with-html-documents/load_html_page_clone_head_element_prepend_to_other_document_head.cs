// Load an HTML page, clone its head element, and prepend it to another document's head.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element with CSS content
            Aspose.Html.HTMLStyleElement styleElement =
                (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "body { background-color: rgb(229, 243, 253); }";
            Aspose.Html.Dom.Text cssNode = document.CreateTextNode(css);
            styleElement.AppendChild(cssNode);

            // Ensure the document has a <head> element
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Access the <body> element and modify its background color via DOM style (optional)
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "rgb(255,255,255)";

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}