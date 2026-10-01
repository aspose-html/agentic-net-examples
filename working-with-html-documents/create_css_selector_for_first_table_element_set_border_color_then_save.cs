// Create a CSS selector for the first table element and set its border-color, then save.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><div id=\"myDiv\">Hello World</div></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Find the element and set an attribute
            Aspose.Html.Dom.Element element = document.QuerySelector("#myDiv");
            element.SetAttribute("style", "color:red;");

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