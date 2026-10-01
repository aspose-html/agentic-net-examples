// Create a reusable method that adds missing alt attributes to images across multiple HTML files.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file with an image lacking an alt attribute
            string inputPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <img src='https://example.com/image.png'>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through the collection and set missing alt attributes
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Auto-generated alt text";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}