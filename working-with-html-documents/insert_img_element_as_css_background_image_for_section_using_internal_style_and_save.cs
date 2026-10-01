// Insert an img element as a CSS background-image for a section using internal style, then save.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
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

            // Create a <style> element and add CSS text
            Aspose.Html.HTMLStyleElement styleElement =
                (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "p { color: red; }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            // Ensure the <head> element exists
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to \"{outputPath}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}