// Replace target="_blank" attributes with rel="noopener noreferrer" to mitigate security risks in the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "input.html";
            string outputPath = "output.html";
            string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <a href='https://example.com' target='_blank'>Example Link</a>
    <a href='https://test.com'>Test Link</a>
</body>
</html>";
            File.WriteAllText(inputPath, sampleHtml);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Find all anchor elements with target='_blank' and set rel attribute
            var anchors = document.GetElementsByTagName("a");
            foreach (var node in anchors)
            {
                var element = node as Aspose.Html.HTMLElement;
                if (element != null && element.GetAttribute("target") == "_blank")
                {
                    element.SetAttribute("rel", "noopener noreferrer");
                }
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}