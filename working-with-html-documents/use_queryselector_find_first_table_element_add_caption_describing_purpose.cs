// Use QuerySelector to find the first table element and add a caption describing its purpose.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content and write to a temporary file
            string inputPath = "sample.html";
            string outputPath = "output.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p id=\"p1\">Hello World</p><p class=\"p2\">Another paragraph</p></body></html>";

            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Select all paragraph elements
            var nodes = document.QuerySelectorAll("p");

            // Modify each selected element
            for (int i = 0; i < nodes.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)nodes[i];
                element.SetAttribute("data-modified", "true");
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}