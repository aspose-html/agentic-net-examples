// Retrieve inner HTML of elements matched by XPath "//div[@class='content']" and log it.

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
                File.WriteAllText(inputPath, "<html><body><div class='test'>Hello, Aspose.HTML!</div></body></html>");
            }

            // Load the HTML document (HTML content string, base URL)
            string htmlContent = File.ReadAllText(inputPath);
            var document = new Aspose.Html.HTMLDocument(htmlContent, ".");

            // Query elements with the class 'test'
            var elements = document.QuerySelectorAll(".test");

            // Iterate over the selected elements
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                Console.WriteLine("Element text: " + element.TextContent);
            }

            // Save the (potentially modified) document to a new file
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}