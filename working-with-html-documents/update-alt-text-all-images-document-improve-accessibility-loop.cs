// Update alt text of all images in the document to improve accessibility using a loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Test Document</h1>
    <img src=""image1.png"">
    <p>Some text here.</p>
    <img src=""image2.jpg"" alt="""">
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Update alt attribute where missing or empty
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
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