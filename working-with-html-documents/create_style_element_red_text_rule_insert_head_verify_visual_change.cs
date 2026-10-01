// Create a style element with a red text rule, insert it into head, and verify visual change.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body style=\"background-color: white;\">Hello World</body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the <body> element and remove its background-color style
            var body = document.GetElementsByTagName("body").First() as Aspose.Html.HTMLElement;
            if (body != null)
            {
                body.Style.RemoveProperty("background-color");
            }

            // Create a new <style> element with the desired background color
            var style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Append the <style> element to the <head>
            var head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}