// Implement error handling for QuerySelector when no element matches the provided selector.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

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
    <button onclick=""alert('Hello')"">Click Me</button>
    <a href=""#"" onclick=""console.log('Link clicked')"">Link</a>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Select all elements that have an onclick attribute
            var elements = document.QuerySelectorAll("[onclick]");

            // Remove the onclick attribute from each selected element
            for (int i = 0; i < elements.Length; i++)
            {
                Element el = (Element)elements[i];
                string attrValue = el.GetAttribute("onclick");
                if (!string.IsNullOrEmpty(attrValue))
                {
                    el.RemoveAttribute("onclick");
                }
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Processing completed. Modified file saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}