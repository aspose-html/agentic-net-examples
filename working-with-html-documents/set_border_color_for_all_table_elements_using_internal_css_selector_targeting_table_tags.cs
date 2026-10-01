// Set border-color for all table elements using an internal CSS selector targeting table tags.

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
                File.WriteAllText(inputPath, "<html><body><div id='myDiv'>Hello</div></body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Find the element and set an attribute
            Aspose.Html.Dom.Element element = document.QuerySelector("#myDiv");
            if (element != null)
            {
                element.SetAttribute("data-sample", "value");
            }

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