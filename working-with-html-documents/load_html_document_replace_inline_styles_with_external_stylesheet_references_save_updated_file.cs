// Load an HTML document, replace inline styles with external stylesheet references, and save the updated file.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body>Hello, Aspose.HTML!</body></html>");
            }

            // Configure behavior using Configuration
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load document with configuration
            var document = new Aspose.Html.HTMLDocument(inputPath, config);

            // Access body element
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Apply style change: set background color
            body.Style.BackgroundColor = "rgb(229, 243, 253)";

            // Save document after background color change
            document.Save(outputPath);

            // Remove the background-color property
            body.Style.RemoveProperty("background-color");

            // Create a <style> element and add CSS rule
            var style = (Aspose.Html.Dom.Element)document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Append the style element to <head>
            var head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save document after adding style element
            document.Save(outputPath);

            // Set background image via inline style
            var bodyElement = document.QuerySelector("body");
            if (bodyElement != null)
            {
                bodyElement.SetAttribute("style", "background-image: url('flower.png');");
            }

            // Save final document with background image
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}