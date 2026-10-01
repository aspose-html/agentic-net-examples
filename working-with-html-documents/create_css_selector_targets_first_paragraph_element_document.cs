// Create a CSS selector that targets the first paragraph element in the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string inputPath = "input.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Modify the first paragraph's style
            Aspose.Html.Dom.Element element = document.QuerySelector("p");
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}